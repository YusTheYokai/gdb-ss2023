using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private GameObject focalPoint;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update() {
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * speed * vertical);
    }
}
