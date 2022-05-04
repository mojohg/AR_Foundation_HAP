using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Calibration : MonoBehaviour
{
    private GameObject calibration;
    Renderer cali_renderer;


    private GameObject unLock_Movement;
    private GameObject lock_Movement;

    private GameObject _calibration_box;
    private Adjust_Calibration adjust_Calibration;
    // Start is called before the first frame update
    void Start()
    {
        
        
        unLock_Movement = GameObject.Find("UnLock");
        unLock_Movement.SetActive(false);
        lock_Movement = GameObject.Find("Lock");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Get_Calibration_Lock()
    {
        _calibration_box = GameObject.Find("Calibration_Box");
        adjust_Calibration = _calibration_box.GetComponent<Adjust_Calibration>();
        adjust_Calibration.Lock_movement();
        lock_Movement.SetActive(false);
        unLock_Movement.SetActive(true);

        calibration = GameObject.FindWithTag("Calibration");
        cali_renderer = calibration.GetComponent<Renderer>();
        cali_renderer.enabled = false;

    }

    public void Get_Calibration_Unlock()
    {
        _calibration_box = GameObject.Find("Calibration_Box");
        adjust_Calibration = _calibration_box.GetComponent<Adjust_Calibration>();
        adjust_Calibration.UnLock_movement();
        lock_Movement.SetActive(true);
        unLock_Movement.SetActive(false);
        cali_renderer.enabled = true;
    }
}
