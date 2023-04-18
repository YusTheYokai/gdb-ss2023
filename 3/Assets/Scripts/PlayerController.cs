using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float gravityModifier;

    private Rigidbody rb;
    private Animator anim;
    private bool onGround = true;
    public bool GameOver { get; private set; } = false;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !GameOver) {
            onGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            onGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            GameOver = true;
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over!");
        }
    }
}
