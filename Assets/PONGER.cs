using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PONGER : MonoBehaviour {

    public bool up, down;
    public float scaleY;
    public int speed;
    private float boundary = 4.3f;
    public float shrinkAmount = 0.1f, pongerShrinkSpeed;

    public bool isShrinking;

    public Vector2 scaleTo;

    // Use this for initialization
    void Start () {
        Invoke("shrink", 1);
        scaleTo = this.transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {



        if (Input.GetKeyDown(KeyCode.W))
        {
            up = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            up = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            down = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            down = false;
        }

        if (up)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        if (down)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        if (!up && !down)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
	}

    public void reset()
    {
        this.transform.localScale = new Vector3(0.4f, scaleY,1);
    }

    public void shrink()
    {
        this.transform.localScale = new Vector2(this.transform.localScale.x, this.transform.localScale.y - shrinkAmount);
        //scaleTo.y -= shrinkAmount;

        if (this.transform.localScale.y <= 1)
        {
            Invoke("grow", pongerShrinkSpeed);
        }
        else
        {
            Invoke("shrink", pongerShrinkSpeed);
        }
    }

    public void grow()
    {

        this.transform.localScale = new Vector2(this.transform.localScale.x, this.transform.localScale.y + shrinkAmount);
        //scaleTo.y += shrinkAmount;

        if (this.transform.localScale.y >= scaleY)
        {
            Invoke("shrink", pongerShrinkSpeed);
        }
        else
        {
            Invoke("grow", pongerShrinkSpeed);
        }
    }
}
