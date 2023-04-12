using TMPro;
using UnityEngine;

public class DetectCollisions : MonoBehaviour {

    public TextMeshProUGUI scoreText;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        Destroy(other.gameObject);
        scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
    }
}
