using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Button singleplayerButton;
    public Button multiplayerButton;

    public Camera playerOneFirstPersonCamera;
    public Camera playerOneThirdPersonCamera;
    public Camera playerTwoFirstPersonCamera;
    public Camera playerTwoThirdPersonCamera;

    public GameObject playerOne;
    public GameObject playerTwo;

    private Rect fullScreen = new(0, 0, 1, 1);
    private Rect halfScreenPlayerOne = new(0, 0, 0.5f, 1);
    private Rect halfScreenPlayerTwo = new(0.5f, 0, 0.5f, 1);

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        Time.timeScale = 0;
        singleplayerButton.onClick.AddListener(Singleplayer);
        multiplayerButton.onClick.AddListener(Multiplayer);
    }

    void Update() {
        if (playerOne.transform.position.y < -10 && (!playerTwo.activeInHierarchy || playerTwo.transform.position.y < -10)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }

    private void Singleplayer() {
        Time.timeScale = 1;
        playerTwo.SetActive(false);

        // Cameras
        playerOneFirstPersonCamera.enabled = false;
        playerOneThirdPersonCamera.enabled = true;
        playerTwoFirstPersonCamera.enabled = false;
        playerTwoThirdPersonCamera.enabled = false;

        playerOneFirstPersonCamera.rect = fullScreen;
        playerOneThirdPersonCamera.rect = fullScreen;

        gameObject.GetComponent<Canvas>().enabled = false;
    }

    private void Multiplayer() {
        Time.timeScale = 1;

        // Cameras
        playerOneFirstPersonCamera.enabled = false;
        playerOneThirdPersonCamera.enabled = true;
        playerTwoFirstPersonCamera.enabled = false;
        playerTwoThirdPersonCamera.enabled = true;

        playerOneFirstPersonCamera.rect = halfScreenPlayerOne;
        playerOneThirdPersonCamera.rect = halfScreenPlayerOne;
        playerTwoFirstPersonCamera.rect = halfScreenPlayerTwo;
        playerTwoThirdPersonCamera.rect = halfScreenPlayerTwo;

        gameObject.GetComponent<Canvas>().enabled = false;
    }
}
