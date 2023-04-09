using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;
    public float xRange = 10;
    public float topYRange = 16;
    public float bottomYRange = -2;

    public GameObject projectilePrefab;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);

        // Keep the player in bounds
        if (transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } else if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < bottomYRange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomYRange);
        } else if (transform.position.z > topYRange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, topYRange);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
