using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour {

    private readonly float leftLimit = -30;
    private readonly float bottomLimit = -5;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit || transform.position.y < bottomLimit) {
            Destroy(gameObject);
        }
    }
}
