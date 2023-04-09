using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
    public GameObject dogPrefab;

    private static readonly float cooldown = 1.0f;
    private float lastDog = -cooldown;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Update() {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDog + cooldown) {
            lastDog = Time.time;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
