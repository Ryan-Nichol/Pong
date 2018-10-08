using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionScript : MonoBehaviour {

    public GameObject camera;
    public Console console;
    public float cameraAcceleration;
    public float cameraMaxSpeed;
    public float cameraSpeed;

    public Vector3 moveCamera;

    public bool inSettings, inHome, inPong;
    public TextMesh ballSpeedText;
    public TextMesh ballSpeedIncreaseText;
    public TextMesh pongerSizeText;
    public TextMesh ballPulsateText;
    public TextMesh pongerShrinkSpeedText;
    public TextMesh pongerShrinkAmountText;
    public TextMesh ballSizeText;
    public TextMesh spawnBallTimerText;
    public TextMesh ballsAtStartText;
    public TextMesh maxBallsText;

    void Start()
    {
        Console console = this.GetComponent<Console>();
    }

    void Update()
    {
        if (camera.transform.position.x > moveCamera.x && inHome)
        {
            camera.transform.Translate(Vector2.left * (cameraSpeed*3) * Time.deltaTime);
            if (cameraSpeed <= cameraMaxSpeed)
            {
                cameraSpeed += cameraAcceleration;
            }
        }

        if (camera.transform.position.x < moveCamera.x && inPong)
        {
            camera.transform.Translate(Vector2.right * (cameraSpeed*3) * Time.deltaTime);
            if (cameraSpeed <= cameraMaxSpeed)
            {
                cameraSpeed += cameraAcceleration;
            }
        }

        if (camera.transform.position.y > moveCamera.y && inSettings)
        {
            camera.transform.Translate(Vector2.down * cameraSpeed * Time.deltaTime);
            if (cameraSpeed <= cameraMaxSpeed)
            {
                cameraSpeed += cameraAcceleration;
            }
        }

        if (camera.transform.position.y < moveCamera.y && inHome)
        {
            camera.transform.Translate(Vector2.up * cameraSpeed * Time.deltaTime);
            if (cameraSpeed <= cameraMaxSpeed)
            {
                cameraSpeed += cameraAcceleration;
            }
        }
        else if (inHome)
        {
            moveCamera.z = -10;
            camera.transform.position = moveCamera;
        }
    }

    public void turnOnBallPulsate()
    {
        console.ballPulsate = true;
        ballPulsateText.text = "YES";
    }

    public void turnOffBallPulsate()
    {
        console.ballPulsate = false;
        ballPulsateText.text = "NO";
    }

    public void increasePongerSize()
    {
        pongerSizeText.text = (int.Parse(pongerSizeText.text) + 1).ToString();
        console.ponger1.scaleY=int.Parse(pongerSizeText.text);
        console.ponger2.scaleY=int.Parse(pongerSizeText.text);
    }
    public void decreasePongerSize()
    {
        if (pongerSizeText.text != "1")
        {
            pongerSizeText.text = (int.Parse(pongerSizeText.text) - 1).ToString();
            console.ponger1.GetComponent<PONGER>().scaleY = int.Parse(pongerSizeText.text);
            console.ponger2.GetComponent<PONGER2>().scaleY = int.Parse(pongerSizeText.text);
        }
    }

    public void addBallSpeed()
    {
        console.increaseBallSpeed();
        ballSpeedText.text = console.ballSpeed.ToString();
    }

    public void removeBallSpeed()
    {
        console.decreaseBallSpeed();
        ballSpeedText.text = console.ballSpeed.ToString();
    }

    public void increaseBallSpeed()
    {
        console.increaseBounce();
        ballSpeedIncreaseText.text = console.ballIncreaseSpeed.ToString();
    }

    public void decreaseBallSpeed()
    {
        console.decreaseBounce();
        ballSpeedIncreaseText.text = console.ballIncreaseSpeed.ToString();
    }

    public void addRound()
    {
        console.addRound();
    }

    public void minusRound()
    {
        console.minusRound();
    }

    public void playPong()
    {
        cameraSpeed = 0;
        moveCamera.y = 0;
        moveCamera.x = 0;
        inPong = true;
        inSettings = false;
        inHome = false;

        console.startNewGame();
    }

    public void openHome()
    {
        cameraSpeed = 0;
        moveCamera.y = 0;
        moveCamera.x = -19;
        inHome = true;
        inSettings = false;
        inPong = false;
    }

    public void openSettings()
    {
        cameraSpeed = 0;
        moveCamera.y = -10;
        inSettings = true;
        inHome = false;
        inPong = false;
    }

    public void increaseBallSize()
    {
        ballSizeText.text = (int.Parse(ballSizeText.text) + 1).ToString();
        console.ballSize = (int.Parse(ballSizeText.text) / (20 / 3));
    }

    public void decreaseBallSize()
    {
        if (ballSizeText.text!="1")
        {
            ballSizeText.text = (int.Parse(ballSizeText.text) - 1).ToString();
            console.ballSize = (int.Parse(ballSizeText.text) / (20 / 3));
        }
    }

    public void decreaseShrinkTime()
    {
        Debug.Log(pongerShrinkSpeedText.text);
        if (pongerShrinkSpeedText.text != "0.1")
        {
            pongerShrinkSpeedText.text = (float.Parse(pongerShrinkSpeedText.text) - 0.1f).ToString();
            console.pongerShrinkSpeed = float.Parse(pongerShrinkSpeedText.text);
        }
    }

    public void increaseShrinkTime()
    {
        pongerShrinkSpeedText.text = (float.Parse(pongerShrinkSpeedText.text)+0.1f).ToString();
        console.pongerShrinkSpeed = float.Parse(pongerShrinkSpeedText.text);
    }

    public void decreaseShrinkAmount()
    {
        if (pongerShrinkAmountText.text != "1")
        {
            pongerShrinkAmountText.text = (float.Parse(pongerShrinkAmountText.text) - 1).ToString();
            console.pongerShrinkAmount = float.Parse(pongerShrinkAmountText.text) / 20;
        }
    }

    public void increaseShrinkAmount()
    {
        pongerShrinkAmountText.text = (float.Parse(pongerShrinkAmountText.text) + 1).ToString();
        console.pongerShrinkAmount = float.Parse(pongerShrinkAmountText.text) / 20;
    }

    public void increaseSpawnBallTimer()
    {
        spawnBallTimerText.text = (int.Parse(spawnBallTimerText.text) + 1).ToString();
        console.spawnBallTimerConstant = int.Parse(spawnBallTimerText.text);
    }

    public void decreaseSpawnBallTimer()
    {
        if (spawnBallTimerText.text != "1")
        {
            spawnBallTimerText.text = (int.Parse(spawnBallTimerText.text) - 1).ToString();
            console.spawnBallTimerConstant = int.Parse(spawnBallTimerText.text);
        }
    }

    public void increaseMaxBalls()
    {
        maxBallsText.text = (int.Parse(maxBallsText.text) + 1).ToString();
        console.maxBalls = (int.Parse(maxBallsText.text));
    }

    public void decreaseMaxBalls()
    {
        if (maxBallsText.text != "1")
        {
            maxBallsText.text = (int.Parse(maxBallsText.text) - 1).ToString();
            console.maxBalls = (int.Parse(maxBallsText.text));
        }
    }

    public void increaseStartBalls()
    {
        ballsAtStartText.text = (int.Parse(ballsAtStartText.text) + 1).ToString();
        console.startWithBalls = (int.Parse(ballsAtStartText.text));
    }

    public void decreaseStartBalls()
    {
        if (ballsAtStartText.text != "1")
        {
            ballsAtStartText.text = (int.Parse(ballsAtStartText.text) - 1).ToString();
            console.startWithBalls = (int.Parse(ballsAtStartText.text));
        }
    }
}
