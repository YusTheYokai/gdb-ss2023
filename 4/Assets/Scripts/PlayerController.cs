using System.Linq;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;
using UnityEditor;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject powerupIndicator;

    private Rigidbody rb;
    private GameObject focalPoint;


    private bool jumped = false;

    private bool bouncePowerup = false;
    private readonly float bouncePowerupStrength = 15.0f;

    public GameObject rocketPrefab;
    private int rocketCount = 3;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update() {
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * speed * vertical);
        powerupIndicator.transform.position = transform.position + Vector3.up;

        if (Input.GetKeyDown(KeyCode.LeftShift) && rocketCount > 0) {
            ShootRocket();
            HidePowerupIndicatorIfNoPowerups();
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            if (jumped) {
                rb.AddForce(Vector3.down * 20, ForceMode.Impulse);
            } else {
                rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
                jumped = true;
            }
        }

        if (transform.position.y < -10) {
            FindObjectOfType<GameManager>().gameOver = true;
        }
    }

    private void ShootRocket() {
        Instantiate(rocketPrefab, transform.position + focalPoint.transform.forward, rocketPrefab.transform.rotation);
        rocketCount--;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bounce Powerup")) {
            bouncePowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        } else if (other.CompareTag("Rocket Powerup")) {
            rocketCount = 3;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject collidingObject = collision.gameObject;
        if (collidingObject.CompareTag("Enemy") && bouncePowerup) {
            Rigidbody enemyRb = collidingObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collidingObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * bouncePowerupStrength, ForceMode.Impulse);
        } else if (collidingObject.CompareTag("Ground")) {
            GameObject.FindGameObjectsWithTag("Enemy").ToList().ForEach(enemy => {
                var distance = Vector3.Distance(enemy.transform.position, transform.position);
                var direction = (enemy.transform.position - transform.position).normalized;
                var force = direction * (collision.impulse.y * 2 / distance);
                force.y = 10;
                enemy.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            });
            jumped = false;
        }
    }

    private IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(7);
        bouncePowerup = false;
        HidePowerupIndicatorIfNoPowerups();
    }

    private void HidePowerupIndicatorIfNoPowerups() {
        if (bouncePowerup == false && rocketCount == 0) {
            powerupIndicator.SetActive(false);
        }
    }
}
