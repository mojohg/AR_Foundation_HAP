using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Connection : MonoBehaviour
{

    public Text Textfield;
    // Start is called before the first frame update
    
    public void SetText(string text)
    {
        Textfield.text = text;
    }
    
}
