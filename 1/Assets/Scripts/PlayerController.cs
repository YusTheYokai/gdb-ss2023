using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 15.0f;
    private float turnSpeed = 50f;
    private float horizontalInput;
    private float forwardInput;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        // Get user inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Turn the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
