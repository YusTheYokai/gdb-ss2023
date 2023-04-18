using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[] obstaclePrefabs;

    private PlayerController playerController;
    private readonly Tuple<float, float> spawnDelayRange = new(0.5f, 3);
    private readonly Tuple<float, float> spawnRange = new(21, 29);

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("SpawnObstacle", GameManager.INTRO_TIME);
    }

    private void SpawnObstacle() {
        if (!playerController.GameOver) {
            var prefab = obstaclePrefabs[UnityEngine.Random.Range(0, obstaclePrefabs.Length)];
            var spawnPosition = new Vector3(UnityEngine.Random.Range(spawnRange.Item1, spawnRange.Item2), 0, 0);
            Instantiate(prefab, spawnPosition, prefab.transform.rotation);
            Invoke("SpawnObstacle", UnityEngine.Random.Range(spawnDelayRange.Item1, spawnDelayRange.Item2));
        }
    }
}
