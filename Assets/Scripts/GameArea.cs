using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour {
    
    private int CountingBallLeft() {
        Debug.Log(GameObject.FindObjectsOfType<BallBehavior>().Length);
        return GameObject.FindObjectsOfType<BallBehavior>().Length; //Total is 16
    }

    private void OnTriggerExit(Collider other) {
        GameObject flyingBall = other.gameObject;

        if (flyingBall.GetComponent<BallBehavior>()) {
            flyingBall.GetComponent<BallBehavior>().Reset();
        }
    }
}
