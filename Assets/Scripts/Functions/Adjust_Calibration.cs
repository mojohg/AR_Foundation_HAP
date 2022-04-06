using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjust_Calibration : MonoBehaviour
{
    public GameObject unLock_Movement;
    public GameObject lock_Movement;
    public GameObject box_Track_renderer;

    private Touch touch;
    private float speedmodifier;

    public bool status;
    // Start is called before the first frame update
   
    void Awake()
    {
        unLock_Movement = GameObject.Find("UnLock");
        lock_Movement = GameObject.Find("Lock");
        
    }
    
    void Start()
    {
        speedmodifier = 0.005f;
        status = false;
        unLock_Movement.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && status == false && Input.touchCount < 2)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedmodifier,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.y * speedmodifier);
            }
        }
    }

   public void Lock_movement()
    {
        status = true;
        lock_Movement.SetActive(false);
        unLock_Movement.SetActive(true);
    }
   public void UnLock_movement()
    {
        status = false;
        lock_Movement.SetActive(true);
        unLock_Movement.SetActive(false);
    }
}
