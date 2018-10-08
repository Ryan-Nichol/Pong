using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerTextScript : MonoBehaviour {

    public bool start;
    public float rotZ;
    public float rotSpeed;
    public float sizeIncSpeed;

	// Update is called once per frame
	void Update () {
		if (start)
        {
            rotZ -= rotSpeed;
            this.transform.rotation = Quaternion.Euler(0, 0, rotZ);

            Vector2 scale = this.transform.localScale;
            scale.x += sizeIncSpeed;
            scale.y += sizeIncSpeed;
            this.transform.localScale = scale;

            if (rotZ < -360)
            {
                rotZ = 0;
            }

            if (this.transform.localScale.x >= 1 && rotZ <= -330)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                start = false;
            }

        }
	}

    public void reset()
    {
        this.transform.localScale = new Vector2(0,0);
    }

    public void startAnimation()
    {
        start = true;
    }
}
