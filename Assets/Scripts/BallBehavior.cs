using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {
    
    public Rigidbody rb;

    private Vector3 ballStartPosition;

    public bool whiteBall = false;

    public bool IsWhite() {
        return whiteBall;
    }

    // Use this for initialization
    void Start() {
        ballStartPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        rb.angularDrag = 6F;
    }

    public void Reset() {
        transform.position = ballStartPosition;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    } 
}
