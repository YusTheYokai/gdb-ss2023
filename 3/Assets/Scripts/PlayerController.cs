using System;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float gravityModifier;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    public TextMeshProUGUI scoreText;

    private Rigidbody rb;
    private Animator anim;
    private AudioSource audioSource;

    private float startTime;
    private bool onGround = true;
    private bool canDoubleJump = true;
    public bool GameOver { get; private set; } = false;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity = new Vector3(0, -9.81f, 0) * gravityModifier;
        startTime = Time.time;
    }

    void Update() {
        if (Time.time - startTime < GameManager.INTRO_TIME) {
            transform.Translate(Vector3.forward * (GameManager.CHARACTER_INTO_MOVE_DISTANCE / GameManager.INTRO_TIME) * Time.deltaTime);
            return;
        }

        anim.SetBool("Run_b", true);
        if (Input.GetKeyDown(KeyCode.Space) && (onGround || canDoubleJump) && !GameOver) {
            if (!onGround) {
                canDoubleJump = false;
            }

            onGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpSound, 0.05f);
        }

        if (!GameOver) {
            scoreText.text = (float.Parse(scoreText.text) + (Time.time - startTime - GameManager.INTRO_TIME) * Time.deltaTime * 100).ToString("0");
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            onGround = true;
            canDoubleJump = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            GameOver = true;
            explosionParticle.Play();
            dirtParticle.Stop();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(crashSound, 0.05f);
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        }
    }
}
