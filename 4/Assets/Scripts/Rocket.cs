using System.Linq;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private float startTime;
    private Rigidbody rb;
    private Enemy target;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        startTime = Time.time;
        rb = GetComponent<Rigidbody>();
        var enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        enemies.Where(e => e.transform.position.y > 0).ToList();

        if (enemies.Count() > 0) {
            target = enemies.OrderBy(e => Vector3.Distance(e.transform.position, transform.position)).First();
        }
    }

    void Update() {
        if (target == null) {
            rb.AddForce(transform.forward * 10);

            if (Time.time - startTime > 10) {
                Destroy(gameObject);
            }

            return;
        }

        transform.LookAt(target.transform);
        var between = target.transform.position - transform.position;
        rb.AddForce(between.normalized * 15);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position).normalized * 15, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
