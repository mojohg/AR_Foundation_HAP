﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using UnityEngine.SceneManagement;

/// <summary>
/// The class MessageHandler contains methods for parsing the messages coming from the IoT adapter and the MES.
/// </summary>

public class MessageHandler : MonoBehaviour
{
    private GameObject assemblies;
    private GameObject product_turns;
    private GameObject product_holder;
    private GameObject feedback_canvas;
    private GameObject feedback_popups;
    private GameObject levelup_confetti;
    private GameObject training_finished_confetti;
    private GameObject task_finished;
    private GameObject final_assembly_green;
    //public GameObject training_finished;

    public int current_knowledge_level;
    public string current_version;
    private string current_producttype;
    private GameObject current_assembly_GO;

    //private string box_name;
    //private string tool_holder_name;
    //private string led_name;
    //private string version_name;
    //private string name_box;
    //private GameObject current_led;
    //private GameObject server;
    //private GameObject boxes;    
    //private GameObject current_storage_area;
    private GameObject active_product_version;
    private List<GameObject> holder_versions;
    private List<GameObject> product_versions;
    private List<GameObject> assembly_items;
    private List<GameObject> turn_versions;
    private List<GameObject> turn_operations;
    private List<GameObject> active_items = new List<GameObject>();
    //private List<GameObject> training_pages = new List<GameObject>();
    private Material assembly_info_material_1;
    private Material assembly_info_material_2;
    private Material finished_info_material;
    private Material error_info_material;
    //private Material toolpoint_material;
    //private Material invisible_material;
    //private CommunicationClass message = new CommunicationClass();

    // UI
    private GameObject current_point_display;
    private GameObject current_action_display;
    private GameObject max_point_display;
    private int max_points;
    private List<GameObject> uncompleted_steps = new List<GameObject>();
    private GameObject object_presentation;
    private GameObject assembly_presentation;

    // UI: Miniature assembly
    private GameObject total_assembly_miniature;
    private List<GameObject> optically_changed_parts = new List<GameObject>();

    // Properties of Assemblies
    private float sizing_factor_v3 = 1.5f;

    void Start()
    {/*
        assembly_info_material_1 = (Material)Resources.Load("Materials/InformationMaterial1", typeof(Material));
        assembly_info_material_2 = (Material)Resources.Load("Materials/InformationMaterial2", typeof(Material));
        finished_info_material = (Material)Resources.Load("Materials/Green", typeof(Material));
        error_info_material = (Material)Resources.Load("Materials/Red", typeof(Material));

        // Find GO
        assemblies = GameObject.Find("Assemblies");
        product_turns = GameObject.Find("ProductTurns");
        product_holder = GameObject.Find("ProductHolder");
        feedback_popups = GameObject.Find("PopupParent");
        object_presentation = GameObject.Find("NextObjects");
        assembly_presentation = GameObject.Find("TotalAssembly");
        levelup_confetti = GameObject.Find("LevelUp");
        training_finished_confetti = GameObject.Find("TrainingFinished");
        task_finished = GameObject.Find("TaskFinished");

        // Find Elements of Feedback Canvas
        feedback_canvas = GameObject.Find("FeedbackCanvas");
        current_action_display = feedback_canvas.transform.Find("ActionInfo").gameObject;
        current_point_display = feedback_canvas.transform.Find("PointDisplay/CurrentPoints").gameObject;
        max_point_display = feedback_canvas.transform.Find("PointDisplay/MaxPoints").gameObject;
    */
        }

    public void InitializeVersion(string version_name)
    {/*
        // Reset everything
        ResetWorkplace();
        feedback_canvas.GetComponent<UI_FeedbackHandler>().ResetNotifications();

        // Set colors of gamification elements
        feedback_canvas.GetComponent<UI_FeedbackHandler>().InitializeQualityRate(80.0f, 60.0f);
        feedback_canvas.GetComponent<UI_FeedbackHandler>().InitializeTimeRate(80.0f, 60.0f);

        // Load new work information
        current_version = version_name;  // Get V3.1
        current_producttype = current_version.Split('.')[0];  // Get V3
        Debug.Log("Load product version " + current_version);
        Debug.Log("Load product type " + current_producttype);
        current_action_display.GetComponent<Text>().text = "Load version " + current_version;

        product_versions = assemblies.GetComponent<AssemblyOrganisation>().main_items_list;
        holder_versions = product_holder.GetComponent<AssemblyOrganisation>().main_items_list;
        turn_versions = product_turns.GetComponent<AssemblyOrganisation>().main_items_list;
        try  // Load product holder
        {
            foreach (GameObject holder in holder_versions)
            {
                if (holder.name == current_version)
                {
                    holder.SetActive(true);
                }
                else
                {
                    holder.SetActive(false);
                }
            }
        }
        catch
        {
            Debug.LogWarning("No product holder specified for version " + current_version);
        }

        try // Load product cad
        {
            foreach (GameObject product in product_versions)
            {
                if (product.name == current_version)
                {
                    current_assembly_GO = product;
                    current_assembly_GO.SetActive(true);

                    try  // Show miniature product
                    {
                        if (total_assembly_miniature != null)
                        {
                            Destroy(total_assembly_miniature);
                        }
                        total_assembly_miniature = Instantiate(current_assembly_GO, new Vector3(0, 0, 0), product.transform.rotation, assembly_presentation.transform);
                        foreach (Transform part in total_assembly_miniature.transform)
                        {
                            if (part.name.Contains("Toolpoint"))
                            {
                                Destroy(part.gameObject);
                            }
                        }
                        total_assembly_miniature.transform.localPosition = new Vector3(0, 0, 0);
                        total_assembly_miniature.transform.localScale = 0.5f * total_assembly_miniature.transform.localScale;
                    }
                    catch
                    {
                        Debug.LogWarning("Product version could not be displayed " + current_version);
                    }

                    assembly_items = product.GetComponent<AssemblyOrganisation>().main_items_list;  // Find GO of assembly
                    foreach (GameObject item in assembly_items)
                    {
                        item.SetActive(false);  // Deactivate GO that they are not visible
                    }
                    active_product_version = product;
                }
                else
                {
                    product.SetActive(false);
                }
            }
        }
        catch
        {
            Debug.LogWarning("Product assembly not found of version " + current_version);
        }

        try  // Load turn operations
        {
            foreach (GameObject ver in turn_versions)
            {
                if (ver.name == current_version)
                {
                    ver.SetActive(true);
                    turn_operations = ver.GetComponent<AssemblyOrganisation>().main_items_list;
                }
                else
                {
                    ver.SetActive(false);
                }
            }
        }
        catch
        {
            Debug.LogWarning("Product turn operations not found of version " + current_version);
        }
   */
    }

    public void InitializeSteps(int number_steps)
    {/*
        Debug.Log("InitializeSteps: " + number_steps.ToString());
        feedback_canvas.GetComponent<UI_FeedbackHandler>().ResetNumberSteps();
        feedback_canvas.GetComponent<UI_FeedbackHandler>().ShowNumberSteps(number_steps);
    }

    public void InitializePoints(int number_points)
    {
        max_points = number_points;
        Debug.Log("InitializePoints: " + max_points.ToString());
        max_point_display.GetComponent<Text>().text = max_points.ToString();
        ShowPoints(0);
    }

    public void NewInstructions()
    {
        Debug.Log("New work step -> reset support");
        ResetWorkplace();
    }

    public void ParsePerformanceMessage(PerformanceProperties msg)
    {
        feedback_canvas.GetComponent<UI_FeedbackHandler>().ShowPoints(msg.total_points);
        feedback_canvas.GetComponent<UI_FeedbackHandler>().ShowQualityRate(msg.quality_performance);
        feedback_canvas.GetComponent<UI_FeedbackHandler>().ShowTimeRate(msg.time_performance);
        feedback_canvas.GetComponent<UI_FeedbackHandler>().ShowLevel(msg.total_level);
        if (msg.node_finished == "True")
        {
            Debug.Log("Step finished");
            feedback_canvas.GetComponent<UI_FeedbackHandler>().FinishStep();
        }
        if (msg.level_up == "True")
        {
            feedback_canvas.GetComponent<UI_FeedbackHandler>().DisplayLevelup();
        }
        if (msg.perfect_run == "True")
        {
            feedback_canvas.GetComponent<UI_FeedbackHandler>().DisplayPerfectRun();
        }
        if (msg.message_text != "")
        {
            feedback_canvas.GetComponent<UI_FeedbackHandler>().DisplayPopup(msg.message_text, msg.message_color.r, msg.message_color.g, msg.message_color.b);
        }*/
    }

    public void PickObject(string item_name, string led_color, int knowledge_level, int default_time)  // TODO: Level System
    {/*
        current_knowledge_level = knowledge_level;

        // Find and show prefab
        GameObject item_prefab = FindPrefab("Prefabs/Parts/" + current_producttype + "/" + item_name, item_name);
        if (item_prefab == null)
        {
            Debug.LogWarning("Prefab for " + item_name + " not found");
            return;
        }
        ShowPickPrefab(item_prefab);

        // Show instructions
        if (led_color == "green")  // Correct pick
        {
            Debug.Log("Show pick instruction for " + item_name);
            current_action_display.GetComponent<Text>().text = "Pick Item";
            feedback_canvas.GetComponent<UI_FeedbackHandler>().StartTimer(default_time);
        }
        else if (led_color == "red")  // Wrong pick
        {
            Debug.Log("Show error pick instruction for " + item_name);
            current_action_display.GetComponent<Text>().text = "Wrong pick, place wrong object in box";
            feedback_canvas.GetComponent<UI_FeedbackHandler>().NotifyWrongAction();
            GameObject item = ShowPickPrefab(item_prefab);
            item.GetComponent<ObjectInteractions>().ChangeMaterial(error_info_material);
        }
        */
    }

    public void PickTool(string tool_name, string led_color, int knowledge_level, int default_time)  // TODO Level System
    {/*
        current_knowledge_level = knowledge_level;

        // Find prefab
        GameObject tool_prefab = FindPrefab("Prefabs/Tools/" + tool_name, tool_name);
        if (tool_prefab == null)
        {
            Debug.LogWarning("Prefab for " + tool_name + " not found");
            return;
        }

        // Show pick instructions
        if (led_color == "green")  // Correct pick
        {
            Debug.Log("Show pick instruction for " + tool_name);
            current_action_display.GetComponent<Text>().text = "Pick tool";
            ShowPickPrefab(tool_prefab);
            feedback_canvas.GetComponent<UI_FeedbackHandler>().StartTimer(default_time);
        }
        else if (led_color == "red")  // Wrong pick
        {
            Debug.Log("Show error pick instruction for " + tool_name);
            current_action_display.GetComponent<Text>().text = "Wrong pick, return tool";
            feedback_canvas.GetComponent<UI_FeedbackHandler>().NotifyWrongAction();
            GameObject tool = ShowPickPrefab(tool_prefab);
            tool.GetComponent<ObjectInteractions>().ChangeMaterial(error_info_material);
        }*/
    }

    public void ReturnTool(string tool_name, string led_color, int knowledge_level, int default_time)
    {/*
        Debug.Log("Show return instruction for " + tool_name);
        current_action_display.GetComponent<Text>().text = "Return Tool";
        current_knowledge_level = knowledge_level;

        // Find prefab
        GameObject tool_prefab = FindPrefab("Prefabs/Tools/" + tool_name, tool_name);
        if (tool_prefab == null)
        {
            Debug.LogWarning("Prefab for " + tool_name + " not found");
            return;
        }
        ShowPickPrefab(tool_prefab);

        // Start timer
        feedback_canvas.GetComponent<UI_FeedbackHandler>().StartTimer(default_time);
        */
    }

    public void ShowAssemblyPosition(string item_name, int knowledge_level, int default_time)
    {/*
        Debug.Log("Show assembly instruction for " + item_name);
        total_assembly_miniature.SetActive(true);
        current_action_display.GetComponent<Text>().text = "Assemble";

        // Highlight assembly position
        foreach (GameObject item in assembly_items)
        {
            if (item.name == item_name)
            {
                item.SetActive(true);
                active_items.Add(item);
                ShowObjectPosition(item, assembly_info_material_1, disable_afterwards: true);
                break;
            }
        }

        // Highlight position in miniature
        GameObject current_mini_part = total_assembly_miniature.transform.Find(item_name).gameObject;
        ShowObjectPosition(current_mini_part, assembly_info_material_1, disable_afterwards: false);

        // Start timer
        feedback_canvas.GetComponent<UI_FeedbackHandler>().StartTimer(default_time);*/
    }

    public void ShowToolUsage(string action_name, int knowledge_level, int default_time)  // TODO: Add animations
    {/*
        Debug.Log("Show tool usage instruction for " + action_name);
        total_assembly_miniature.SetActive(true);
        current_action_display.GetComponent<Text>().text = "Assemble with tool";

        // Highlight toolpoint
        foreach (GameObject item in assembly_items)
        {
            if (item.name == action_name)
            {
                item.SetActive(true);
                active_items.Add(item);
                ShowObjectPosition(item, assembly_info_material_2, disable_afterwards: true);
                break;
            }
        }

        // Start timer
        feedback_canvas.GetComponent<UI_FeedbackHandler>().StartTimer(default_time);*/
    }

    public void ShowPoints(int current_points)
    {/*
        current_point_display.GetComponent<Text>().text = current_points.ToString();
        float ratio = current_points / max_points;

        if (ratio > 0.8f)
        {
            current_point_display.GetComponent<Text>().color = Color.green;
        }
        else if (ratio > 0.4f)
        {
            current_point_display.GetComponent<Text>().color = Color.cyan;
        }
        else
        {
            current_point_display.GetComponent<Text>().color = Color.yellow;
        }*/
    }

    public void FinishStep()
    {/*
        uncompleted_steps[0].GetComponent<Image>().color = Color.green;
        uncompleted_steps.RemoveAt(0);*/
    }

    public void FinishJob()
    {/*
        current_assembly_GO.GetComponent<ObjectInteractions>().ActivateAllChildren();

        final_assembly_green = Instantiate(current_assembly_GO);
        current_assembly_GO.SetActive(false);
        final_assembly_green.GetComponent<ObjectInteractions>().ChangeMaterial(finished_info_material);
        task_finished.GetComponent<AudioSource>().Play();
        current_action_display.GetComponent<Text>().text = "Task finished; remove assembly";
    */
    }

    private void ShowObjectPosition(GameObject current_object, Material material, bool disable_afterwards)
    {/*
        if (current_object.GetComponent<ObjectInteractions>() != null)
        {
            current_object.GetComponent<ObjectInteractions>().ChangeMaterial(material);
            if (disable_afterwards)
            {
                active_items.Add(current_object);
            }
            else
            {
                optically_changed_parts.Add(current_object);
            }
        }
        else
        {
            current_object.AddComponent<ObjectInteractions>();
            current_object.GetComponent<ObjectInteractions>().ChangeMaterial(material);
            active_items.Add(current_object);
        }
        */
    }

    public void ResetWorkplace()
    {/*
        if (object_presentation.transform.childCount > 0)
        {
            foreach (Transform child in object_presentation.transform)
            {
                Destroy(child.gameObject);
            }
            object_presentation.transform.DetachChildren();  // Remove children from parent, otherwise childCount is not working in same frame
        }
        if (active_items.Count() > 0)
        {
            foreach (GameObject item in active_items)
            {
                item.SetActive(false);
            }
        }
        if (optically_changed_parts.Count() > 0)
        {
            foreach (GameObject part in optically_changed_parts.ToList())
            {
                part.GetComponent<ObjectInteractions>().ResetMaterial();
                optically_changed_parts.Remove(part);
            }
        }
        if (total_assembly_miniature != null)
        {
            total_assembly_miniature.SetActive(false);
        }
        if (final_assembly_green != null)
        {
            Destroy(final_assembly_green);
        }
        active_items.Clear();
        feedback_canvas.GetComponent<UI_FeedbackHandler>().ResetNotifications();
        */
    }

    public GameObject FindGameobject(string name, List<GameObject> gameobject_list)
    {/*
        foreach (GameObject obj in gameobject_list)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        Debug.LogWarning("Gameobject " + name + " not found");
        */
        return null;

        
    }

    private GameObject ShowPickPrefab(GameObject prefab)
    {
        // Instantiate prefab and set parent
        GameObject displayed_item = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        /*   Vector3 original_scale = displayed_item.transform.localScale;
           displayed_item.transform.parent = object_presentation.transform;
           displayed_item.transform.localRotation = prefab.transform.rotation;
           displayed_item.transform.localScale = original_scale * sizing_factor_v3;

           // Check if several pick options exist
           int number_pick_options = object_presentation.transform.childCount;
           Vector3 offset = new Vector3(0.5f, 0, 0);

           if (number_pick_options == 1)  // Show prefab at first pick position
           {
               displayed_item.transform.localPosition = new Vector3(0, 0, 0);
           }
           else  // Show prefab at subsequent pick position
           {
               Debug.Log("Number of pick options: " + number_pick_options.ToString());
               int movement = number_pick_options - 1;
               displayed_item.transform.localPosition = new Vector3(0, 0, 0) + movement * offset;
           }

           // Add properties
           if (displayed_item.GetComponent<ObjectInteractions>() == null)
           {
               displayed_item.AddComponent<ObjectInteractions>();
           }
           */
        return displayed_item;
        
    }
    /*
    private GameObject FindPrefab(string path_name, string prefab_name)
    {
        GameObject prefab = (GameObject)Resources.Load(path_name, typeof(GameObject));
         if (prefab == null)
         {
             Debug.LogWarning("Prefab not found:" + prefab_name);
         }
        return prefab;
        
    }*/
}