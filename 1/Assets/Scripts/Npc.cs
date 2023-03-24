using System;
using System.Threading;
using UnityEngine;

public class Npc : MonoBehaviour {

    public float speed = 1f;
    public float delay = 0f;
    private bool move = false;

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    void Start() {
        Invoke("StartMoving", delay);
    }

    void Update() {
        if (move) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void StartMoving() {
        move = true;
    }
}
