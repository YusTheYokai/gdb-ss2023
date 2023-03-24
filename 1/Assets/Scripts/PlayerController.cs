using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    private float speed = 15.0f;
    private float turnSpeed = 50f;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        firstPersonCamera.enabled = false;
        thirdPersonCamera.enabled = true;
    }

    void Update() {
        // Move the vehicle
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));

        // Turn the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * Input.GetAxis("Horizontal"));

        // Switch cameras
        if (Input.GetKeyDown(KeyCode.Space)) {
            firstPersonCamera.enabled = !firstPersonCamera.enabled;
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
        }
    }
}
