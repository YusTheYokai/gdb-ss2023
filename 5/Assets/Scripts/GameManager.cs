using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;

    private readonly float spawnRate = 1.0f;
    private int score;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    void Start() {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    private IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
