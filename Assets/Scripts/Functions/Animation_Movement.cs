using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation_Movement : MonoBehaviour
{
   
    public float smoothTime = 0.5f;
    public float speed = 10;
    private Vector3 velocity = Vector3.zero;
    Vector3 targetPosition; 
   
    void Start()
    {

    }
   public void Move_x_left()
    {
        targetPosition = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
    }
    
    public void Move_x_right()
    {
        targetPosition = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
    }

    public void Move_y_back()
    {
        targetPosition = new Vector3(transform.position.x , transform.position.y + 0.1f, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);

    }
    public void Move_y_forward()
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);

    }

    public void Move_z_up()
    {
        targetPosition = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z + 0.1f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
    }

    public void Move_z_down()
    {
        targetPosition = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z + 0.1f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
    }
    
}
