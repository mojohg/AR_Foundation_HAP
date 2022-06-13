using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ListRecipe
{
    public class workstep
    {
        public string name;
        public string skill;
        public string edges;
        public string parts;
        public string tools;
        public string action;

       

        public workstep(string _name, string _skill, string _edges, string _parts, string _tools, string _action)
        {
            name = _name;
            skill = _skill;
            edges = _edges;
            parts = _parts;
            tools = _tools;
            action = _action;
        }

    }

    public class Manual_Mode : MonoBehaviour
    {
        private GameObject _audio;
        private Audio_All audio_All;
        public static List<workstep> worksteps = new List<workstep>();
        public static int i = 0;


        // Start is called before the first frame update
        public void Start()
        {
            _audio = GameObject.Find("Audio");
            audio_All = (Audio_All)_audio.GetComponent("Audio_All");
           

            //1.
            worksteps.Add(new workstep("Pick_holder_1", "Pick", "Place_holder_1", "part_1", "None", "None"));
            //2.
            worksteps.Add(new workstep("Place_holder_1", "Place", "Pick_nut_1", "Holder_1", "None", "None"));
            //3.
            worksteps.Add(new workstep("Pick_nut_1", "Pick", "Place_nut_1", "part_2", "None", "None"));
            //4.
            worksteps.Add(new workstep("Place_nut_1", "Place", "Pick_Screw_1", "Nut_1", "None", "None"));
            //5.
            worksteps.Add(new workstep("Pick_Screw_1", "Pick", "Pick_Screwdriver_1", "part_3", "None", "None"));
            //6.
            worksteps.Add(new workstep("Pick_Screwdriver_1", "Pick", "Mount_Screw_1", "part_4", "Screwdriver", "None"));
            //7.
            worksteps.Add(new workstep("Mount_Screw_1", "Screw", "Pick_bar_1", "Screw_1", "Drill_1", "None"));
            //8.
            worksteps.Add(new workstep("Pick_bar_1", "Pick", "Place_bar_1", "part_5", "None", "None"));
            //9.
            worksteps.Add(new workstep("Place_bar_1", "Place", "Pick_Module_1.1", "Bar_1", "None", "None"));
            //10.
            worksteps.Add(new workstep("Pick_Module_1.1", "Pick", "Place_Module_1", "Module_1_1", "None", "None"));
            //11.
            worksteps.Add(new workstep("Place_Module_1.1", "Place", "Pick_Screw_2", "Module_1_1", "None", "None"));
            //12.
            worksteps.Add(new workstep("Pick_Screw_2", "Pick", "Pick_Screwdriver_2", "part_3", "None", "None"));
            //13.
            worksteps.Add(new workstep("Pick_Screwdriver_2", "Pick", "Mount_Screw_2", "part_4", "Screwdriver", "None"));
            //14.
            worksteps.Add(new workstep("Mount_Screw_2", "Screw", "Pick_Module_2", "Screw_1", "Drill_2", "None"));
            //15.
            worksteps.Add(new workstep("Pick_Module_1.2", "Pick", "Place_Module_2", "Module_1_2", "None", "None"));
            //16.
            worksteps.Add(new workstep("Place_Module_1.2", "Place", "Pick_Module_1.2", "Module_1_2", "None", "None"));
            //17.
            worksteps.Add(new workstep("Pick_Module_2", "Pick", "Place_Module_1.2", "Module_2", "None", "None"));
            //18.
            worksteps.Add(new workstep("Place_Module_2", "Place", "Pick_Screw_3", "Module_2", "None", "None"));
            //19.
            worksteps.Add(new workstep("Pick_Screw_3", "Pick", "Pick_Screwdriver_3", "part_3", "None", "None"));
            //20.
            worksteps.Add(new workstep("Pick_Screwdriver_3", "Pick", "Mount_Screw_3", "part_4", "Screwdriver", "None"));
            //21.
            worksteps.Add(new workstep("Mount_Screw_3", "Screw", "Pick_Cover_1", "Screw_1", "Drill_3", "None"));
            //22.
            worksteps.Add(new workstep("Pick_Cover_1", "Pick", "Mount_Cover_1", "part_6", "None", "None"));
            //23.
            worksteps.Add(new workstep("Mount_Cover_1", "Mount", "Pick_Cover_2", "Cover_1", "None", "None"));
            //24.
            worksteps.Add(new workstep("Pick_Cover_2", "Pick", "Mount_Cover_2", "part_6", "None", "None"));
            //25.
            worksteps.Add(new workstep("Mount_Cover_2", "Mount", "Pick_Cover_3", "Cover_2", "None", "None"));
            //26.
            worksteps.Add(new workstep("Pick_Cover_3", "Pick", "Mount_Cover_3", "part_7", "None", "None"));
            //27.
            worksteps.Add(new workstep("Mount_Cover_3", "Mount", "Pick_Cover_4", "Cover_3", "None", "None"));
            //28.
            worksteps.Add(new workstep("Pick_Cover_4", "Pick", "Mount_Cover_4", "part_7", "None", "None"));
            //29.
            worksteps.Add(new workstep("Mount_Cover_4", "Mount", "None", "Cover_4","None", "None"));

            Debug.Log(worksteps[i].name);

        }
               
        public void Next()
        {
            if (i < worksteps.Count - 1)
            {
                ++i;
                Debug.Log(worksteps[i].name);
                audio_All.Sound_Step_Right();
            }
        }

        public void Previous()
        {
            if (i > 0)
            {
                --i;
                Debug.Log(worksteps[i].name);
                audio_All.Sound_Step_False();
            }
        }

        public void Reset()
        {
            i = 0;
        }
        
    }
}

