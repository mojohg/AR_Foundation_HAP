using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Calibration : MonoBehaviour
{
    private GameObject calibration;
    Renderer cali_renderer;


    public GameObject unLock_Movement;
    public GameObject lock_Movement;

    private GameObject _calibration_models;
    private GameObject _calibration_targets;
    private GameObject _calibration_boxes;
    private Adjust_Calibration adjust_Calibration_models;
    private Adjust_Calibration adjust_Calibration_targets;
    private Adjust_Calibration adjust_Calibration_boxes;
    // Start is called before the first frame update
    void Awake()
    {
        
        
       
        unLock_Movement.SetActive(false);
        
    }
    public void Find_Calibration_Items()
    {
        _calibration_boxes = GameObject.Find("Boxes");
        _calibration_models = GameObject.Find("Models");
        _calibration_targets = GameObject.Find("Targets");


        adjust_Calibration_boxes = _calibration_boxes.GetComponent<Adjust_Calibration>();
        adjust_Calibration_targets = _calibration_targets.GetComponent<Adjust_Calibration>();
        adjust_Calibration_models = _calibration_models.GetComponent<Adjust_Calibration>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Get_Calibration_Lock()
    {
        
        
        adjust_Calibration_models.Lock_movement();
       
        adjust_Calibration_targets.Lock_movement();
        
        adjust_Calibration_boxes.Lock_movement();

        lock_Movement.SetActive(false);
        unLock_Movement.SetActive(true);

        //calibration = GameObject.FindWithTag("Calibration");
        //cali_renderer = calibration.GetComponent<Renderer>();
        //cali_renderer.enabled = false;

    }

    public void Get_Calibration_Unlock()
    {
        adjust_Calibration_models.UnLock_movement();

        adjust_Calibration_targets.UnLock_movement();

        adjust_Calibration_boxes.UnLock_movement();

        //_calibration_box = GameObject.Find("Calibration_Box");
        // adjust_Calibration = _calibration_box.GetComponent<Adjust_Calibration>();
        //adjust_Calibration.UnLock_movement();
        lock_Movement.SetActive(true);
        unLock_Movement.SetActive(false);
        //cali_renderer.enabled = true;
    }
}
