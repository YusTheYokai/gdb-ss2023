using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {

    public int difficulty;

    private GameManager _gameManager;
    private Button _button;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////
    
    void Start() {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty() {
        _gameManager.StartGame(difficulty);
    }
}
