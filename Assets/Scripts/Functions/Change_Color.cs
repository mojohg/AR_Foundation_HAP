using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Color : MonoBehaviour
{
    public Color myColor;
    public float rFloat;
    public float gFloat;
    public float bFloat;
    public float aFloat;   
    private Color defaultColor;

    public Renderer myRenderer;

    private bool blink;
    

    
    void Update()
    {if (blink == true)
        {
            myRenderer = gameObject.GetComponent<Renderer>();
            if (gFloat < 1)
            {
                gFloat += 1 * Time.deltaTime;
            }
            else
            {
                gFloat = 0;
            }
            myColor = new Color(rFloat, gFloat, bFloat, aFloat);
            myRenderer.material.color = myColor;
            Debug.Log("BLinkKKK");
            return;
        }
    }
    // Function to highlight Box dynamic
    public void Light_Box_Blink()
    {
        blink = true;
        Debug.Log("Blink");
    }

    // Function to highlight Box static
    public void Light_Box()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
        myColor = new Color(rFloat, gFloat, bFloat, aFloat);
        myRenderer.material.color = myColor;
        return;
    }
    // Function to Reset to default color
    public void Reset_Box()
    {
        myRenderer.material.color = defaultColor;
        return;
    }
    

}
