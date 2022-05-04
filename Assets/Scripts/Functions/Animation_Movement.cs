using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation_Movement : MonoBehaviour
{
   
    public float smoothTime = 0.5f;
    public float speed = 10;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    private Vector3 start_position;
    private bool run;
    private bool saved;
    void Start()
    {

    }
    void Awake()
    {
       

    }
    private void Update()
    {
        if (run == true)
        {

            if (saved == false)
            {
                start_position = transform.position;
                saved = true;
            }
                
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));
            //targetPosition = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
           
            if (transform.position == targetPosition)
            {
                transform.position = start_position;
                Debug.Log("Arrived");
                Debug.Log(start_position);
            }
        }
       

    }
    public void Move()
    {
        run = true;
        
        
    }
    
}
