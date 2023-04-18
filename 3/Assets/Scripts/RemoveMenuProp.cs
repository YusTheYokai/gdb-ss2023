using UnityEngine;

public class RemoveMenuProp : MonoBehaviour {

    private bool removing = false;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !removing) {
            removing = true;
            Invoke("Destroy", GameManager.INTRO_TIME / 4);
        }
    }

    private void Destroy() {
        Destroy(gameObject);
    }
}
