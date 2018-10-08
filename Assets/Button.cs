using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Color highlight, pressed, normal;
    public SpriteRenderer[] sprites;
    public TextMesh[] texts;

    public FunctionScript fs;
    public string functioName;

    private void Start()
    {
        fs = GameObject.FindGameObjectWithTag("Console").GetComponent<FunctionScript>();
    }

    public void invokeFunction()
    {
        fs.Invoke(functioName,0);
    }

    public void updateColor(Color color)
    {
        if (sprites != null)
        {
            foreach (SpriteRenderer r in sprites)
            {
                r.color = color;
            }
        }
        if (texts != null)
        {
            foreach (TextMesh t in texts)
            {
                t.color = color;
            }
        }
    }

    private void OnMouseEnter()
    {
        updateColor(highlight);
    }

    private void OnMouseExit()
    {
        updateColor(normal);
    }

    private void OnMouseDown()
    {
        updateColor(pressed);
        Debug.Log("Down");
    }

    private void OnMouseUpAsButton()
    {
        updateColor(highlight);
        invokeFunction();
        Debug.Log("Activate");
    }

    private void OnMouseUp()
    {
        
    }
}
