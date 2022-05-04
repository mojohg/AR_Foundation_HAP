using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_behaviour : MonoBehaviour
{
    public Text Textfield;
    // Variables Animation
    public float smoothTime = 0.5f;
    public float speed = 10;
    private Vector3 velocity = Vector3.zero;
    Vector3 targetPosition;
    //
    // Variables Color
    public Color myColor;
    public float rFloat;
    public float gFloat;
    public float bFloat;
    public float aFloat;
    private Color defaultColor;


   

    public Renderer myRenderer;
    //
    public bool run;

    public bool light_up;

    public GameObject box;

    public GameObject model;

  

    private Animation_Movement animation_Movement;

    private Change_Color change_color;

    void Awake()
    {
       

    }

    void Update()
    {
        
        
       

       
    }

    //Animations
    public void Move_Animation()
    {
        model = GameObject.FindWithTag("Model");
       
       
        animation_Movement  = model.GetComponent<Animation_Movement>();
        Debug.Log("Move");

        animation_Movement.Move();
       
    }

   

    // Color
    public void Light_Box_Blink()
    {

        box = GameObject.FindWithTag("Box");
        change_color = box.GetComponent<Change_Color>();

        change_color.Light_Box_Blink();

    }

    public void Light_Box()
    {
        box = GameObject.FindWithTag("Box");
        change_color = box.GetComponent<Change_Color>();
        change_color.Light_Box();

    }
    // Function to Reset to default color
    public void Reset_Box()
    {
        change_color.Reset_Box();
    }
}