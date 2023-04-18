using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject obstaclePrefab;

    private readonly float startDelay = 2;
    private readonly float repeatRate = 2;
    private readonly Vector3 spawnPos = new(25, 0, 0);

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle() {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }

    void Update() {
        
    }
}
