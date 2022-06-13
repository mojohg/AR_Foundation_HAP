using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class UI_Handler : MonoBehaviour
{
    private GameObject WIFI;
    private GameObject NO_WIFI;
    private GameObject Panel;
    private GameObject Settings_button;
    private GameObject Confirm_button;
    private GameObject Debug_text;
    private GameObject Text_Background;
    private GameObject Log;
    private GameObject BackButtonManager;
    private GameObject Audio;
    private GameObject Mute;
    private GameObject Sound_on;
    


    private GameObject[] Inital_Scene;
    private GameObject[] Setting_Scene;
    private GameObject[] Manualmode_Scene;

    private bool Setting_Scene_loaded = false;
    private bool Manualmode_Scene_loaded = false;
    private bool Inital_Scene_loaded = false;

    


    // Start is called before the first frame update
    void Start()
    {
        Mute = GameObject.Find("Mute");
        Sound_on = GameObject.Find("Sound_on");
        Audio = GameObject.Find("Audio");
        NO_WIFI = GameObject.Find("NO_WIFI");
        WIFI = GameObject.Find("WIFI");
        Setting_Scene = GameObject.FindGameObjectsWithTag("Setting_Scene");
        Manualmode_Scene = GameObject.FindGameObjectsWithTag("Manualmode_Scene");
        Inital_Scene = GameObject.FindGameObjectsWithTag("Inital_Scene");
       

        Load_Inital_Scene();
        
    }

    
    public void Load_Setting_Scene()
    {
       
        if (Setting_Scene_loaded == false)
        {
            

            foreach (GameObject setting_Scene in Setting_Scene)
            {
                setting_Scene.SetActive(true);
            }
            Setting_Scene_loaded = true;
            return;
        }
        else 
        {
            foreach (GameObject setting_Scene in Setting_Scene)
            {
                setting_Scene.SetActive(false);
            }
            Setting_Scene_loaded = false;
            return;
        }
    }

    public void Load_Manual_Mode()
    {
        if (Manualmode_Scene_loaded == false)
        {
            foreach (GameObject manualmode_Scene in Manualmode_Scene)
            {
                manualmode_Scene.SetActive(true);
            }
            Manualmode_Scene_loaded = true;
            return;
        }

        else
        {
            foreach (GameObject manualmode_Scene in Manualmode_Scene)
            {
                manualmode_Scene.SetActive(false);
            }
            Manualmode_Scene_loaded = false;
            return;
        }
    }


    public void Load_Inital_Scene()
    {
        

        foreach (GameObject inital_Scene in Inital_Scene)
        {
            inital_Scene.SetActive(true);
        }
        foreach (GameObject setting_Scene in Setting_Scene)
        {
            setting_Scene.SetActive(false);
        }
        foreach (GameObject manualmode_Scene in Manualmode_Scene)
        {
            manualmode_Scene.SetActive(false);
        }
        Sound_on.SetActive(false);
        return;
    }
    public void Show_Connection_State(bool connected)
    {
      
        
        if(connected ==true)
        {
            WIFI.SetActive(true);
            NO_WIFI.SetActive(false);
        }
        else
        {
            WIFI.SetActive(false);
            NO_WIFI.SetActive(true);
        }

    }
    public void Sounds_OFF()
    {
        Audio.SetActive(false);
        Sound_on.SetActive(true);
        Mute.SetActive(false);

    }
    public void Sounds_ON()
    {
        Audio.SetActive(true);
        Sound_on.SetActive(false);
        Mute.SetActive(true);

    }


}
