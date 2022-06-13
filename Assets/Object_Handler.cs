using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class target
{
    private string name;
    public GameObject target_GO;

    public target(string _name, GameObject gameObject)
    {
        gameObject = GameObject.Find(_name);
        target_GO = gameObject;
        name = _name;

    }
}

public class model
{
    public string name;
    public GameObject model_GO;
    public Animation_Movement animation_Movement;
    public Change_Color change_Color;
    public model(string _name, GameObject gameObject)
    {
        gameObject = GameObject.Find(_name);
        animation_Movement = gameObject.GetComponent<Animation_Movement>();
        change_Color = gameObject.GetComponent<Change_Color>();
        model_GO = gameObject;
        name = _name;

    }
}

public class box
{
    public string name;
    public GameObject box_GO;
    public Change_Color change_Color;

    public box(string _name, GameObject gameObject)
    {
        gameObject = GameObject.Find(_name);
        change_Color = gameObject.GetComponent<Change_Color>();
        box_GO = gameObject;
        name = _name;

    }
}



public class Object_Handler : MonoBehaviour
{
    //References Scripts
    private ListRecipe.Manual_Mode manual_Mode;
    private GameObject Manual_Mode_Handler;
    private Text_dynamic text_Dynamic;
    private GameObject Textfield_Manager;
    


    public static List<target> targets = new List<target>();
    public static List<box> boxes = new List<box>();
    public static List<model> models = new List<model>();



    private GameObject Target_1;
    private GameObject Target_2;
    private GameObject Target_3;
    private GameObject Target_4;
    private GameObject Target_5;
    private GameObject Target_6;
    private GameObject Target_7;
    private GameObject Target_8;
    private GameObject Target_9;
    private GameObject Target_10;
    private GameObject Target_11;
    private GameObject Target_12;
    private GameObject Target_13;
    private GameObject Target_14;
    private GameObject Target_15;
    private GameObject Target_16;
    private GameObject Bar_1;
    private GameObject Cover_1;
    private GameObject Cover_2;
    private GameObject Cover_3;
    private GameObject Cover_4;
    private GameObject Screw_1;
    private GameObject Screw_2;
    private GameObject Screw_3;
    private GameObject Nut_1;
    private GameObject Holder_1;
    private GameObject Module_1_1;
    private GameObject Module_1_2;
    private GameObject Module_2;
    private GameObject Module_Check;
    private GameObject Drill_1;
    private GameObject Drill_2;
    private GameObject Drill_3;
    private GameObject part_1;
    private GameObject part_2;
    private GameObject part_3;
    private GameObject part_4;
    private GameObject part_5;
    private GameObject part_6;
    private GameObject part_7;
    private GameObject part_8;
    private GameObject part_9;
    private GameObject part_10;
    private GameObject part_11;
    private GameObject part_12;

    private bool Manual_State = false;
    private bool List_added = false;

    void Start()
    {
        Manual_Mode_Handler = GameObject.Find("Manual_Mode_Handler");
        manual_Mode = Manual_Mode_Handler.GetComponent<ListRecipe.Manual_Mode>();
        Textfield_Manager = GameObject.Find("Textfield_Manager");
        text_Dynamic = Textfield_Manager.GetComponent<Text_dynamic>();

    }
    public void Awake_Instantiated()
    {
        if (List_added == false)
        {
            targets.Add(new target("Target_1", Target_1));
            targets.Add(new target("Target_2", Target_2));
            targets.Add(new target("Target_3", Target_3));
            targets.Add(new target("Target_4", Target_4));
            targets.Add(new target("Target_5", Target_5));
            targets.Add(new target("Target_6", Target_6));
            targets.Add(new target("Target_7", Target_7));
            targets.Add(new target("Target_8", Target_8));
            targets.Add(new target("Target_9", Target_9));
            targets.Add(new target("Target_10", Target_10));
            targets.Add(new target("Target_11", Target_11));
            targets.Add(new target("Target_12", Target_12));
            targets.Add(new target("Target_13", Target_13));
            targets.Add(new target("Target_13", Target_14));
            targets.Add(new target("Target_13", Target_15));
            targets.Add(new target("Target_13", Target_16));

            models.Add(new model("Cover_1", Cover_1));
            models.Add(new model("Cover_2", Cover_2));
            models.Add(new model("Cover_3", Cover_3));
            models.Add(new model("Cover_4", Cover_4));
            models.Add(new model("Screw_1", Screw_1));
            models.Add(new model("Screw_2", Screw_2));
            models.Add(new model("Screw_3", Screw_3));
            models.Add(new model("Nut_1", Nut_1));
            models.Add(new model("Holder_1", Holder_1));
            models.Add(new model("Module_1_1", Module_1_1));
            models.Add(new model("Module_1_2", Module_1_2));
            models.Add(new model("Module_2", Module_2));
            models.Add(new model("Module_Check", Module_Check));
            models.Add(new model("Bar_1", Bar_1));
            models.Add(new model("Drill_1", Drill_1));
            models.Add(new model("Drill_2", Drill_2));
            models.Add(new model("Drill_3", Drill_3));

            boxes.Add(new box("part_1", part_1));
            boxes.Add(new box("part_2", part_2));
            boxes.Add(new box("part_3", part_3));
            boxes.Add(new box("part_4", part_4));
            boxes.Add(new box("part_5", part_5));
            boxes.Add(new box("part_6", part_6));
            boxes.Add(new box("part_7", part_7));
            boxes.Add(new box("part_8", part_8));
            boxes.Add(new box("part_9", part_9));
            boxes.Add(new box("part_10", part_10));
            boxes.Add(new box("part_11", part_11));
            boxes.Add(new box("part_12", part_12));
            List_added = true;
        }

    }
    public void State_Toggle()
    {
        if (Manual_State == false)
        {
            Manual_State = true;
        }
        else Manual_State = false;
    }


    public void Update()
    {
        Debug.Log(Manual_State);
        string _name = ListRecipe.Manual_Mode.worksteps[ListRecipe.Manual_Mode.i].name;
        string _skill = ListRecipe.Manual_Mode.worksteps[ListRecipe.Manual_Mode.i].skill;
        string _edges = ListRecipe.Manual_Mode.worksteps[ListRecipe.Manual_Mode.i].edges;
        string _parts = ListRecipe.Manual_Mode.worksteps[ListRecipe.Manual_Mode.i].parts;
        string _tools = ListRecipe.Manual_Mode.worksteps[ListRecipe.Manual_Mode.i].tools;
        string _action = ListRecipe.Manual_Mode.worksteps[ListRecipe.Manual_Mode.i].action;

        if (Manual_State == true)
        {   
            text_Dynamic.Show_Instructions(_skill + " " + _parts);
        }
        else text_Dynamic.Show_Instructions("Waiting for Instructions...");

        foreach (box _box in boxes)
        {
            if (_box.name == _parts && Manual_State == true)
            {
                _box.change_Color.Light_Box_Blink();
                Debug.Log("BLINK");

            }
            else _box.change_Color.Reset_Box();

        }

        foreach (target _target in targets)
        {
            // _target.target_GO.SetActive(false);
        }

        foreach (model _model in models)
        {
            if (_skill == "Place" && Manual_State == true)
            {
                if (_model.name == _parts)
                {
                    Debug.Log(_parts);
                    _model.model_GO.SetActive(true);
                    _model.animation_Movement.Move();

                }


            }
            else if (_skill == "Screw" && Manual_State == true)
            {
                if (_model.name == _tools)
                {
                    _model.model_GO.SetActive(true);
                    _model.animation_Movement.Move();
                }
               /* if (_model.name == _parts)
                {
                    _model.model_GO.SetActive(true);
                    _model.animation_Movement.Move();
                }
               */
            }
            else if (_skill == "Mount" && Manual_State == true)
            {
                if (_model.name == _parts)
                {
                    _model.model_GO.SetActive(true);
                    _model.animation_Movement.Move();
                }
            }
            else
            {
                _model.model_GO.SetActive(false);
                _model.animation_Movement.Stop();
            }

            if (_skill == "Pick" && Manual_State == true)
            {
                if (_model.name == _parts)
                {

                    _model.model_GO.SetActive(true);
                    _model.change_Color.Light_Box_Blink();
                }
                else _model.change_Color.Reset_Box();

            }
            

            



        }


    }
}
