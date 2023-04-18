using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float gravityModifier;

    private Rigidbody rb;
    private bool onGround = true;
    public bool GameOver { get; private set; } = false;

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
        if (collision.gameObject.CompareTag("Ground")) {
            onGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            GameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
