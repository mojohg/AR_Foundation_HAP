using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Color : MonoBehaviour
{
    public Color myColor;
    private float rFloat = 0;
    private float gFloat = 0;
    private float bFloat = 0;
    private float aFloat;   
    private Color defaultColor = Color.white;

    public Renderer myRenderer;

    private bool blink;
    

    
    void Update()
    {if (blink == true)
        {
            myRenderer = gameObject.GetComponent<Renderer>();
            if (bFloat < 1)
            {
                bFloat += 1 * Time.deltaTime;
            }
            else
            {
                bFloat = 0;
            }
            myColor = new Color(rFloat, gFloat, bFloat, aFloat);
            myRenderer.material.color = myColor;
            
            return;
        }
    }
    // Function to highlight Box dynamic
    public void Light_Box_Blink()
    {
        blink = true;
        
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
