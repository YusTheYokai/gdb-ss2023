using UnityEngine;

public class Target : MonoBehaviour {

    public int pointValue;
    public ParticleSystem explosionParticle;

    private GameManager _gameManager;
    private Rigidbody _rigidbody;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    private Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown() {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        _gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
