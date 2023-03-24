using UnityEngine;

public class FollowPlayerX : MonoBehaviour {

    public GameObject plane;
    private Vector3 offset = new(25, 0, 5);

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        transform.position = plane.transform.position + offset;
    }
}
