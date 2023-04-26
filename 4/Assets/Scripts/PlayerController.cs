using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject powerupIndicator;

    private Rigidbody rb;
    private GameObject focalPoint;


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
