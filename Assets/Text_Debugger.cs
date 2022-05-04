using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Debugger : MonoBehaviour
{

    public Text Debugger;

    public void Print_Debugger(string _text)
    {
        Debugger.text = _text;
    }
}
