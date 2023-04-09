using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;
    public float xRange = 10;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);

        // Keep the player in bounds
        if (transform.position.x < -xRange) {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        } else if (transform.position.x > xRange) {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
    }
}
