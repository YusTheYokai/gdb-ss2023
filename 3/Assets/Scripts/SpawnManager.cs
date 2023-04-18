using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject obstaclePrefab;

    private PlayerController playerController;
    private readonly float startDelay = 2;
    private readonly float repeatRate = 2;
    private readonly Vector3 spawnPos = new(25, 0, 0);


    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle() {
        if (!playerController.GameOver) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
