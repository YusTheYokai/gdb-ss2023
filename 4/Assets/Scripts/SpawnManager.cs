using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject heavierEnemyPrefab;
    public GameObject[] powerupPrefabs;
    private int waveNumber = 1;
    private readonly float spawnRange = 9;
    private GameManager gameManager;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {
        if (gameManager.gameStarted && FindObjectsOfType<Enemy>().Length == 0) {
            var prefab = powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];
            Instantiate(prefab, GenerateSpawnPosition(), prefab.transform.rotation);
            SpawnEnemyWave(waveNumber++);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn) {
        for (int i = 0; i < enemiesToSpawn; i++) {
            GameObject prefab = enemyPrefab;

            if (Random.Range(0, 3) == 0) {
                prefab = heavierEnemyPrefab;
            }

            Instantiate(prefab, GenerateSpawnPosition(), prefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new (spawnPosX, 0, spawnPosZ);
    }
}
