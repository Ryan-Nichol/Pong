using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    public GameObject ball;

    public float ballSpeed, ballIncreaseSpeed, pongerShrinkAmount, pongerShrinkSpeed;
    public Text leftText;
    public Text rightText;

    public float ballSize;
    public bool ballPulsate;
    public float leftScore = 0;
    public float rightScore = 0;
    public float rounds=3;

    public int startWithBalls = 1;
    public int currentBalls = 1;
    public float spawnBallTimer = 3;
    public int maxBalls = 1;
    public float spawnBallTimerConstant;
    private float spawnBall;

    public bool gameRunning;
    public bool waitForWinner;
    public GameObject winnerParticles;

    public GameObject winnerText;
    public TextMesh roundText;

    public PhysicsMaterial2D ballPhysics;

    public PONGER ponger1;
    public PONGER2 ponger2;

    public float totalWinnerParticles;

	// Use this for initialization
	void Start () {
        rounds = 3;
        ballSpeed = 3;
        ballIncreaseSpeed = 1;
        ballSize = 0.6f;
        ballPulsate = false;
        pongerShrinkSpeed = 1;
        pongerShrinkAmount = 0.1f;

        startWithBalls = 1;

        currentBalls = 0;

        spawnBallTimer = 5;
        spawnBallTimerConstant = spawnBallTimer;

        maxBalls = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (gameRunning && currentBalls < maxBalls)
        {
            spawnBallTimer -= Time.deltaTime;
            if (spawnBallTimer <= 0)
            {
                spawnNewBall();
                spawnBallTimer = spawnBallTimerConstant;
                currentBalls++;
            }
        }

        if ((leftScore == rounds || rightScore == rounds) && !waitForWinner)
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            foreach(GameObject b in balls)
            {
                Destroy(b);
            }

            if (leftScore == rounds)
            {
                winnerText.GetComponent<TextMesh>().text="LEFT PLAYER\nWINS";
            }
            else
            {
                winnerText.GetComponent<TextMesh>().text = "RIGHT PLAYER\nWINS";
            }

            winnerText.GetComponent<WinnerTextScript>().startAnimation();
            waitForWinner = true;
            gameRunning = false;
            totalWinnerParticles = 10;
            spawnWinnerParticles();
            this.GetComponent<FunctionScript>().Invoke("openHome", 3);
        }
	}

    public void spawnWinnerParticles()
    {
        Instantiate(winnerParticles, new Vector2(Random.Range(-8, 8), Random.Range(-3.5f, 3.5f)), Quaternion.Euler(0, 0, 0));

        if (totalWinnerParticles > 0)
        {
            Invoke("spawnWinnerParticles", Random.Range(0.1f, 0.6f));
        }

        totalWinnerParticles--;
    }

    public void increaseBallSpeed()
    {
        ballSpeed++;
    }

    public void decreaseBallSpeed()
    {
        if (ballSpeed > 1)
        {
            ballSpeed--;
        }
       
    }

    public void increaseBounce()
    {
        ballIncreaseSpeed++;
        Debug.Log(ballIncreaseSpeed / 10);
    }

    public void decreaseBounce()
    {
        if (ballIncreaseSpeed > 1)
        {
            ballIncreaseSpeed--;
        }

    }

    public void addRound()
    {
        if (rounds < 20)
        {
            rounds++;
            roundText.text = rounds.ToString();
        }
    }

    public void minusRound()
    {
        if (rounds > 1)
        {
            rounds--;
            roundText.text = rounds.ToString();
        }
    }

    public void startNewGame()
    {
        ponger1.reset();
        ponger2.reset();
        ballPhysics.bounciness = 1+(ballIncreaseSpeed/10);
        gameRunning = true;
        waitForWinner = false;
        leftScore = 0;
        rightScore = 0;
        winnerText.GetComponent<WinnerTextScript>().reset();

        spawnBallTimer = spawnBallTimerConstant;

        ponger1.pongerShrinkSpeed = pongerShrinkSpeed;
        ponger1.shrinkAmount = pongerShrinkAmount;
        ponger2.pongerShrinkSpeed = pongerShrinkSpeed;
        ponger2.shrinkAmount = pongerShrinkAmount;

        currentBalls = 0;

        for (int i = 0; i < startWithBalls; i++)
        {
            if (currentBalls < maxBalls)
            {
                Invoke("spawnNewBall", 2);
                currentBalls++;
            }
        }
    }

    public void spawnNewBall()
    {
        GameObject newBall = Instantiate(ball, new Vector3(0, -1, 0), Quaternion.Euler(0, 0, 0));
        newBall.GetComponent<Ball>().speed = ballSpeed*50;
        newBall.GetComponent<Ball>().size = ballSize;
        newBall.GetComponent<Ball>().pulsate = ballPulsate;
    }

    public void leftScored()
    {
        leftScore++;
        //leftText.text = leftScore.ToString();
        spawnNewBall();
    }

    public void rightScored()
    {
        rightScore++;
        //rightText.text = rightScore.ToString();
        spawnNewBall();
    }
}
