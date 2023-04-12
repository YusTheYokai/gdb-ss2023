using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Canvas titleScreen;

    public Canvas scoreCanvas;
    public TextMeshProUGUI scoreText;

    public Canvas gameOverScreen;
    public TextMeshProUGUI finalScoreText;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        Time.timeScale = 0;
        titleScreen.gameObject.SetActive(true);
        scoreCanvas.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (titleScreen.gameObject.activeInHierarchy) {
                titleScreen.gameObject.SetActive(false);
                scoreCanvas.gameObject.SetActive(true);
                Time.timeScale = 1;
            } else if (gameOverScreen.gameObject.activeInHierarchy) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
                Time.timeScale = 1;
            }
        }
    }

    public void GameOver() {
        finalScoreText.text = scoreText.text;
        scoreCanvas.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        Invoke("RestartGame", 3);
        Time.timeScale = 0;
    }
}
