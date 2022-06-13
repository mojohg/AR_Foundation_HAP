using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textfield : MonoBehaviour
{
    public Text my_text;
    
    // Update is called once per frame
    public void Show_Instruction(string _instruction)
    {
        my_text.text = _instruction;        
    }
}
