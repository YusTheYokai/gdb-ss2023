using UnityEngine;

public class RotateCamera : MonoBehaviour {

    public float rotationSpeed;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);
    }
}
