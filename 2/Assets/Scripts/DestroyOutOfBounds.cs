using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {

    public float topBound = 30.0f;
    public float lowerBound = -10.0f;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        if (transform.position.z > topBound || transform.position.z < lowerBound) {
            Destroy(gameObject);
        }
    }
}
