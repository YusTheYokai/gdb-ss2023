using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool HasPowerup { get; private set; }
    public float speed;
    public GameObject powerupIndicator;

    private Rigidbody rb;
    private GameObject focalPoint;
    private readonly float powerupStrength = 15.0f;

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
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            HasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject collidingObject = collision.gameObject;
        if (collidingObject.CompareTag("Enemy") && HasPowerup) {
            Rigidbody enemyRb = collidingObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collidingObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(7);
        HasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}
