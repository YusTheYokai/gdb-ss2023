using UnityEngine;

public class MoveLeft : MonoBehaviour {

    public float speed = 10.0f;

    private PlayerController playerController;
    private float startTime;
    private readonly float leftBound = -15;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        startTime = Time.time;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update() {
        if (!playerController.GameOver) {
            if (CompareTag("Background") && Time.time - startTime < GameManager.INTRO_TIME) {
                transform.Translate(Vector3.left * (GameManager.CHARACTER_INTO_MOVE_DISTANCE / GameManager.INTRO_TIME) * Time.deltaTime);
            } else {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
