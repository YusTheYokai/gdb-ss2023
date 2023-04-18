using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[] obstaclePrefabs;

    private PlayerController playerController;
    private readonly float repeatRate = 2;
    private readonly Vector3 spawnPos = new(25, 0, 0);


    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", GameManager.INTRO_TIME, repeatRate);
    }

    private void SpawnObstacle() {
        if (!playerController.GameOver) {
            var prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(prefab, spawnPos, prefab.transform.rotation);
        }
    }
}
