using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {

    private int points;
    
    public Text score;

    public int COLOURED_BALL_PTS = 1;
    public int WHITE_BALL_PTS = -1;
    private int MAX_BALLS = 16;

    private bool started;
    public GameObject fullRack;
    public BallBehavior whiteBall;

    // Use this for initialization
    void Start () {
        score.text = points.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        score.text = CountingScore().ToString();

        if (CountingBallLeft().Equals(1) && started) { 
            //Reset score
            points = 0;
            score.text = points.ToString();

            //Reset game
            startNewGame();
            whiteBall.Reset();
        }

        if (CountingBallLeft().Equals(MAX_BALLS)) {
            started = true;
        }
    }

    private void startNewGame() {
        started = false;
        GameObject newBalls = Instantiate(fullRack);
        newBalls.transform.position += new Vector3(0, 10, 0);
    }

    private int CountingScore() {
        return points;
    }

    private int CountingBallLeft () {
        return GameObject.FindObjectsOfType<BallBehavior>().Length; //Total is 16
    }

    private void updateScore(BallBehavior ballDropped) {
        if (!ballDropped.IsWhite()) {
            //points++;
            points += COLOURED_BALL_PTS;
        } else {
            //points--;
            points += WHITE_BALL_PTS;
            ballDropped.Reset();
        }
    }

    private void OnTriggerExit(Collider other) {
        GameObject ballGameObj = other.gameObject;
        BallBehavior ballDropped = ballGameObj.GetComponent<BallBehavior>();

        if (ballDropped) {
            updateScore(ballDropped);
        }

        if (!ballDropped.IsWhite()) {
            Destroy(ballGameObj);
        }
    }
}
