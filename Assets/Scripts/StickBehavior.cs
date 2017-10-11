using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBehavior : MonoBehaviour {
    
    public Vector3 vt = new Vector3();
    public Rigidbody rball;     //Rigidbody of ball
    public GameObject stick1;   //object stick
    public GameObject ball;     //object ball

    public Transform target; //White Ball
    public float fRadius = 3.0f;
    public Transform pivot;
        
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

    // Use this for initialization
    void Start() {
        pivot = new GameObject().transform;
        stick1.transform.parent = pivot;
    }

    // Update is called once per frame
    void Update() {
        Roll();
        vt = (ball.transform.position - stick1.transform.position);

        if (Input.GetMouseButtonDown(0)) {
            stick1.SetActive(false);
            rball.velocity = vt * 3;
        }
        if (Input.GetMouseButtonDown(1)) {
            stick1.SetActive(true);
        }
    }

    //Controll stick rotate around white ball
    void Roll() {
        Vector3 v3Pos = Camera.main.WorldToScreenPoint(target.position);
                
        v3Pos = Input.mousePosition - v3Pos;
        float angle = Mathf.Atan2(v3Pos.x, v3Pos.y) * Mathf.Rad2Deg;
        
        pivot.position = target.position;
        pivot.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
