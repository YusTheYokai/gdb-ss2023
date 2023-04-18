using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float gravityModifier;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Rigidbody rb;
    private Animator anim;
    private AudioSource audioSource;

    private float startTime;
    private bool onGround = true;
    public bool GameOver { get; private set; } = false;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        startTime = Time.time;
    }

    void Update() {
        if (Time.time - startTime < GameManager.INTRO_TIME) {
            transform.Translate(Vector3.forward * (GameManager.CHARACTER_INTO_MOVE_DISTANCE / GameManager.INTRO_TIME) * Time.deltaTime);
            return;
        }

        anim.SetBool("Run_b", true);
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !GameOver) {
            onGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpSound, 0.05f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            onGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            GameOver = true;
            explosionParticle.Play();
            dirtParticle.Stop();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(crashSound, 0.05f);
        }
    }
}
