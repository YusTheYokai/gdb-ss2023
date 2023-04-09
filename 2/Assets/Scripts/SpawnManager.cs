using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[] animalPrefabs;

    private readonly float startDelay = 2.0f;
    private readonly float spawnInterval = 1.5f;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal() {
        // select random animal
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        // select random x coordinate
        int x = Random.Range(-15, 16);

        Instantiate(animalPrefabs[animalIndex], new Vector3(x, 0, 25), animalPrefabs[animalIndex].transform.rotation);
    }
}
