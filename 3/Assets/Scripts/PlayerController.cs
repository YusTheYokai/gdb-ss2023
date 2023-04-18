using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float gravityModifier;

    private Rigidbody rb;
    private bool onGround = true;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && onGround) {
            onGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        onGround = true;
    }
}
