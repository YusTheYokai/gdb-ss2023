using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<GameObject> targets;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public bool gameActive;

    private float spawnRate = 1.0f;
    private int lives;
    private int score;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    public void StartGame(int difficulty) {
        gameActive = true;
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateLives(3);
        UpdateScore(0);
    }

    public void UpdateLives(int livesToAdd) {
        lives += livesToAdd;
        livesText.text = "Lives: " + lives;

        if (lives <= 0) {
            GameOver();
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator SpawnTarget() {
        while (gameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    private void GameOver() {
        gameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
