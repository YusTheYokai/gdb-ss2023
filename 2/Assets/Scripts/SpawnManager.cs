using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[] animalPrefabs;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            // select random animal
            int animalIndex = Random.Range(0, animalPrefabs.Length);

            // select random x coordinate
            int x = Random.Range(-20, 21);

            Instantiate(animalPrefabs[animalIndex], new Vector3(x, 0, 25), animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
