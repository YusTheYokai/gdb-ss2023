using UnityEngine;

public class MoveLeft : MonoBehaviour {

    public float speed = 10.0f;

    private PlayerController playerController;
    private readonly float leftBound = -15;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update() {
        if (!playerController.GameOver) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
