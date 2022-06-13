using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_dynamic : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
        text.text = "Test";
    }

    // Update is called once per frame
    public void Show_Instructions(string _instruction)
    {
        text.text = _instruction;
    }
}
