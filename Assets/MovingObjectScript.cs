using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectScript : MonoBehaviour {

    public Vector2 topPosition, botPosition;
    public float speed;
    public bool up;

	// Use this for initialization
	void Start () {
		//if (Random.Range(0, 2) == 1)
  //      {
  //          up = true;
  //      }
  //      else
  //      {
  //          up = false;
  //      }
	}
	
	// Update is called once per frame
	void Update () {
		
        if (this.transform.position.y > topPosition.y)
        {
            up = false;
        }
        if (this.transform.position.y < botPosition.y)
        {
            up = true;
        }

        if (up)
        {
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

	}
}
