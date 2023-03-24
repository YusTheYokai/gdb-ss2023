using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    public string verticalInputName;
    public string horizontalInputName;
    public KeyCode switchCameraKeyCode;

    private float speed = 15.0f;
    private float turnSpeed = 50f;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        // Move the vehicle
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis(verticalInputName));

        // Turn the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * Input.GetAxis(horizontalInputName));

        // Switch cameras

        if (Input.GetKeyDown(switchCameraKeyCode)) {
            firstPersonCamera.enabled = !firstPersonCamera.enabled;
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
        }
    }
}
