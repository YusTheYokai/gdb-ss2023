using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<GameObject> targets;
    public AudioClip explosionSound;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public GameObject pauseMenu;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public bool gameActive;

    private float _spawnRate = 1.0f;
    private int _lives;
    private int _score;

    private AudioSource _audioSource;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    public void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && gameActive) {
            bool pause = Time.timeScale == 1.0f;

            Time.timeScale = pause ? 0.0f : 1.0f;
            pauseMenu.gameObject.SetActive(pause);
        }
    }

    public void StartGame(int difficulty) {
        gameActive = true;
        _spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateLives(3);
        UpdateScore(0);
    }

    public void ChangeVolumn(float volume) {
        _audioSource.volume = volume;
    }

    public void UpdateLives(int livesToAdd) {
        _lives += livesToAdd;
        livesText.text = "Lives: " + _lives;

        if (_lives <= 0) {
            GameOver();
        }
    }

    public void UpdateScore(int scoreToAdd) {
        _score += scoreToAdd;
        scoreText.text = "Score: " + _score;
    }

    public void PlayTargetExplosionEffect() {
        _audioSource.PlayOneShot(explosionSound, 1.0f);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator SpawnTarget() {
        while (gameActive) {
            yield return new WaitForSeconds(_spawnRate);
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
