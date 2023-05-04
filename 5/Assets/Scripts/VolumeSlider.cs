using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
    
    private GameManager _gameManager;
    private Slider _slider;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(volume => _gameManager.ChangeVolumn(volume));
    }
}
