using UnityEngine;

public class PropellerSpin : MonoBehaviour {

    void Update() {
        transform.Rotate(Vector3.forward * Time.deltaTime * 1000);
    }
}
