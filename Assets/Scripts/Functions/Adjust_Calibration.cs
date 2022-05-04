using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjust_Calibration : MonoBehaviour
{
    private GameObject unLock_Movement;
    private GameObject lock_Movement;

   

    private Touch touch;
    private float speedmodifier;
   // private float speedmodifier_rot;
    

    private bool status;
    private bool TouchStatus = false;

    private Text_Debugger text_Debugger;
    private GameObject _Debugger;

    // Start is called before the first frame update
   
    void Awake()
    {
        _Debugger = GameObject.Find("Debug");
        
        text_Debugger = _Debugger.GetComponent<Text_Debugger>();
    }
    
    void Start()
    {
        speedmodifier = 0.0005f;
        status = false;
        unLock_Movement.SetActive(false);
        //speedmodifier_rot = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
       
        var fingerCount = 0;
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        if (fingerCount ==2)
        {
            TouchStatus = true;
            text_Debugger.Print_Debugger("FingerCount = 2");
        }
        else
        {
            TouchStatus = false;
            text_Debugger.Print_Debugger("FingerCount = 1");
        }
        

        if (status == false && TouchStatus == false)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * speedmodifier,
                        transform.position.y,
                        transform.position.z + touch.deltaPosition.y * speedmodifier);
                        text_Debugger.Print_Debugger("Position");
                }
            }
            Debug.Log("In Update status" + status);
        }

        if(TouchStatus == true && status ==false)
        {
            Touch screenTouch = Input.GetTouch(0);
            if(screenTouch.phase == TouchPhase.Moved)
            {
                transform.Rotate(0f, screenTouch.deltaPosition.x  , 0f);
                text_Debugger.Print_Debugger("Rotation");
            }
        }
       

    }

   public void Lock_movement()
    {
        status = true;
       
        Debug.Log("status = true");
       
        Debug.Log(status);
        Debug.Log(TouchStatus);

    }
   public void UnLock_movement()
    {
        status = false;
       
        Debug.Log("status = false");
       
        Debug.Log(status);
        Debug.Log(TouchStatus);
    }
}
