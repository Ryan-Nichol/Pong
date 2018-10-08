using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PONGER2 : MonoBehaviour
{

    public bool up, down;
    public int speed;
    public float scaleY;
    private float boundary = 4.3f;
    public float shrinkAmount=0.1f, pongerShrinkSpeed;

    // Use this for initialization
    void Start()
    {
        Invoke("shrink", 1);
    }

    // Update is called once per frame
    void Update()
    {

      

        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            up = true;
        }
        else if (Input.GetKeyUp(KeyCode.Joystick1Button3))
        {
            up = false;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            down = true;
        }
        else if (Input.GetKeyUp(KeyCode.Joystick1Button0))
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

    public void shrink()
    {

        this.transform.localScale = new Vector2(this.transform.localScale.x, this.transform.localScale.y - shrinkAmount);

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

        if (this.transform.localScale.y >= scaleY)
        {
            Invoke("shrink", pongerShrinkSpeed);
        }
        else
        {
            Invoke("grow", pongerShrinkSpeed);
        }
    }

    public void reset()
    {
        this.transform.localScale = new Vector3(0.4f, scaleY, 1);
    }
}
