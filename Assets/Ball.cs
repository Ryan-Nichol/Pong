using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed;
    public Console con;
    public GameObject particles, particlesHit;
    public float waitFor;

    public bool pulsate;
    public float pulsateSpeed;

    private bool pulsateGrow;
    private bool hasFired;

    public float size;

	// Use this for initialization
	void Start () {
        con = GameObject.FindGameObjectWithTag("Console").GetComponent<Console>();
        Invoke("fire", waitFor);
	}


    public void fire()
    {
        int direction = Random.Range(0, 2);
        int angle = Random.Range(20, 45);

        Vector2 d = new Vector2();
        d.y = 0;
        if (Random.Range(0, 2) == 0)
        {
            d.y += Random.Range(0.2f, 0.45f);
        }
        else
        {
            d.y -= Random.Range(0.2f, 0.45f);
        }

        if (direction == 0)
        {
            d.x = -1;
            this.GetComponent<Rigidbody2D>().AddForce(d * speed);
        }else if (direction == 1)
        {
            d.x = 1;
            this.GetComponent<Rigidbody2D>().AddForce(d * speed);
        }
        hasFired = true;
    }

    public void kill()
    {
        Instantiate(particles, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

	// Update is called once per frame
	void Update () {

        this.GetComponentInChildren<ParticleSystem>().startSize = this.transform.localScale.x / 3;

        if (!hasFired)
        {
            if (this.transform.localScale.x < size)
            {
                Vector2 scale = this.transform.localScale;
                scale.x += 0.04f;
                scale.y += 0.04f;
                this.transform.localScale = scale;
            }
            else
            {
                this.transform.localScale = new Vector2(size, size);
            }
        }
        else if (pulsate)
        {
            Vector2 scale = this.transform.localScale;
            
            if (pulsateGrow)
            {
                if (scale.x < size)
                {
                    scale.x += size / pulsateSpeed;
                    scale.y += size / pulsateSpeed;
                }
                else
                {
                    pulsateGrow = false;
                }
            }
            else
            {
                if (scale.x > 0.2f)
                {
                    scale.x -= size / pulsateSpeed;
                    scale.y -= size / pulsateSpeed;
                }
                else
                {
                    pulsateGrow = true;
                }
            }

            this.transform.localScale = scale;
        }

        if (this.GetComponent<Rigidbody2D>().velocity.y == 0 && hasFired)
        {
            Vector2 d = new Vector2();
            d.y = 1;
            this.GetComponent<Rigidbody2D>().AddForce(d * 50);
        }
        if (this.GetComponent<Rigidbody2D>().velocity.x >= -0.1f && hasFired && this.GetComponent<Rigidbody2D>().velocity.x <= 0.1f && hasFired)
        {
            Vector2 d = new Vector2();
            if (this.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                d.x = -1;
            }
            else
            {
                d.x = 1;
            }
            this.GetComponent<Rigidbody2D>().AddForce(d * 50);
        }

        if (this.transform.position.y > 5)
        {
            kill();
        }
        if (this.transform.position.y < -5)
        {
            kill();
        }

        if (this.transform.position.x < -8.9f)
        {
            con.rightScored();
            kill();
        }
        if (this.transform.position.x > 8.9f)
        {
            con.leftScored();
            kill();
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(particlesHit, this.transform.position, this.transform.rotation);
        Debug.Log(col.gameObject.name);
    }

}
