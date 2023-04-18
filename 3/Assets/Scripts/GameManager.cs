using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static readonly float INTRO_TIME = 2.0f;
    public static readonly float CHARACTER_INTO_MOVE_DISTANCE = 3.0f;

    public Canvas mainMenu;
    public Canvas gameOverlay;
    public TextMeshProUGUI scoreText;
    public Canvas gameOverMenu;
    public TextMeshProUGUI finalScoreText;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        Time.timeScale = 0;
        mainMenu.gameObject.SetActive(true);
        gameOverlay.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Time.timeScale = 1;
            mainMenu.gameObject.SetActive(false);
            gameOverlay.gameObject.SetActive(true);
        }
    }

    public void GameOver() {
        finalScoreText.text += scoreText.text;
        gameOverlay.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(true);
        Invoke("ResetGame", 3.0f);
    }

    private void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
