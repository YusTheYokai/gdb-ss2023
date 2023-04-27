using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool gameOver = false;
    public bool gameStarted = false;

    public Canvas menu;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        Time.timeScale = 0;
        menu.enabled = true;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && !gameStarted) {
            Time.timeScale = 1;
            menu.enabled = false;
            gameStarted = true;
        }

        if (gameOver) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
