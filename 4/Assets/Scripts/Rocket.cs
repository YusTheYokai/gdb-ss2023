using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody rb;
    private Enemy target;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        rb = GetComponent<Rigidbody>();
        var enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        target = enemies[Random.Range(0, enemies.Length)];
    }

    void Update() {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        // TODO: adjust y rotation to face target
        rb.AddForce((target.transform.position - transform.position).normalized * 10);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position).normalized * 10, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
