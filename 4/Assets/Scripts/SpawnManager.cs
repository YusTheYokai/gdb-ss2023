using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject enemyPrefab;
    private readonly float spawnRange = 9;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new (spawnPosX, 0, spawnPosZ);
    }
}
