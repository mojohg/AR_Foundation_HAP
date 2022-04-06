using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
   
    [RequireComponent(typeof(ARAnchorManager))]
    [RequireComponent(typeof(ARRaycastManager))]
    public class AnchorCreator : MonoBehaviour
    {
        [SerializeField]
        GameObject m_Prefab;

        [SerializeField]
        GameObject Canvas;

        
        

        //Only one Object can be added
        public bool object_added = false;



        public GameObject prefab
        {
            get => m_Prefab;
            set => m_Prefab = value;
        }

        public void RemoveAllAnchors()
        {
            Logger.Log($"Removing all anchors ({m_Anchors.Count})");
            foreach (var anchor in m_Anchors)
            {
                Destroy(anchor.gameObject);
            }
            m_Anchors.Clear();
            
            object_added = false;
        }

        void Awake()
        {
           
            m_RaycastManager = GetComponent<ARRaycastManager>();
            m_AnchorManager = GetComponent<ARAnchorManager>();
        }

        void SetAnchorText(ARAnchor anchor, string text)
        {
            var canvasTextManager = anchor.GetComponent<CanvasTextManager>();
            if (canvasTextManager)
            {
                canvasTextManager.text = text;
            }
        }

        ARAnchor CreateAnchor(in ARRaycastHit hit)
        {
            
                ARAnchor anchor = null;

                // If we hit a plane, try to "attach" the anchor to the plane
                if (hit.trackable is ARPlane plane && object_added == false)
                {
                    var planeManager = GetComponent<ARPlaneManager>();
                    if (planeManager)
                    {
                        Logger.Log("Creating anchor attachment.");
                        var oldPrefab = m_AnchorManager.anchorPrefab;
                        m_AnchorManager.anchorPrefab = prefab;
                        anchor = m_AnchorManager.AttachAnchor(plane, hit.pose);
                        m_AnchorManager.anchorPrefab = oldPrefab;
                        SetAnchorText(anchor, $"Attached to plane {plane.trackableId}");
                        return anchor;
                    }
                }

                // Otherwise, just create a regular anchor at the hit pose
                Logger.Log("Creating regular anchor.");

                // Note: the anchor can be anywhere in the scene hierarchy
                var gameObject = Instantiate(prefab, hit.pose.position, hit.pose.rotation);

                // Make sure the new GameObject has an ARAnchor component
                anchor = gameObject.GetComponent<ARAnchor>();
                if (anchor == null && object_added == false)
                {
                    anchor = gameObject.AddComponent<ARAnchor>();
                }


                SetAnchorText(anchor, $"Anchor (from {hit.hitType})");
                // Set to true that no Object can be added before old was removed
                object_added = true;
                return anchor;
            
        }

        



       public void Update()
        {
            if (Input.touchCount == 0)
                return;

            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Began)
                return;

            // Raycast against planes and feature points
            const TrackableType trackableTypes =
                TrackableType.FeaturePoint |
                TrackableType.PlaneWithinPolygon;

            // Perform the raycast
            if (m_RaycastManager.Raycast(touch.position, s_Hits, trackableTypes) && object_added == false)
            {
                // Raycast hits are sorted by distance, so the first one will be the closest hit.
                var hit = s_Hits[0];

               
                    // Create a new anchor
                    var anchor = CreateAnchor(hit);
              
                // Reference GameObjects Models
                GameObject cover_1 = anchor.transform.Find("Cover_1").gameObject;
                GameObject cover_2 = anchor.transform.Find("Cover_2").gameObject;
                GameObject bar = anchor.transform.Find("Bar").gameObject;
                GameObject nut = anchor.transform.Find("Nut").gameObject;
                GameObject screw = anchor.transform.Find("Screw").gameObject;
                GameObject holder_1 = anchor.transform.Find("Holder_1").gameObject;
                GameObject holder_2 = anchor.transform.Find("Holder_2").gameObject;

                // Reference GameObjects Boxes
                GameObject part_1 = anchor.transform.Find("part_1").gameObject;
                GameObject part_2 = anchor.transform.Find("part_2").gameObject;
                GameObject part_3 = anchor.transform.Find("part_3").gameObject;
                GameObject part_4 = anchor.transform.Find("part_4").gameObject;
                GameObject part_5 = anchor.transform.Find("part_5").gameObject;
                GameObject part_6 = anchor.transform.Find("part_6").gameObject;
                GameObject part_7 = anchor.transform.Find("part_7").gameObject;
                GameObject part_8 = anchor.transform.Find("part_8").gameObject;
                GameObject part_9 = anchor.transform.Find("part_9").gameObject;
                GameObject part_10 = anchor.transform.Find("part_10").gameObject;
                GameObject part_11 = anchor.transform.Find("part_11").gameObject;
                GameObject part_12 = anchor.transform.Find("part_12").gameObject;

                // Reference Change_Color
                Change_Color light_1 = part_1.GetComponent<Change_Color>();
                Change_Color light_2 = part_2.GetComponent<Change_Color>();
                Change_Color light_3 = part_3.GetComponent<Change_Color>();
                Change_Color light_4 = part_4.GetComponent<Change_Color>();
                Change_Color light_5 = part_5.GetComponent<Change_Color>();
                Change_Color light_6 = part_6.GetComponent<Change_Color>();
                Change_Color light_7 = part_7.GetComponent<Change_Color>();
                Change_Color light_8 = part_8.GetComponent<Change_Color>();
                Change_Color light_9 = part_9.GetComponent<Change_Color>();
                Change_Color light_10 = part_10.GetComponent<Change_Color>();
                Change_Color light_11 = part_11.GetComponent<Change_Color>();
                Change_Color light_12 = part_12.GetComponent<Change_Color>();

                // Reference Animation
                Animation_Movement move_cover_1 = cover_1.GetComponent<Animation_Movement>();
                Animation_Movement move_cover_2 = cover_2.GetComponent<Animation_Movement>();
                Animation_Movement move_holder_1 = holder_1.GetComponent<Animation_Movement>();
                Animation_Movement move_holder_2 = holder_2.GetComponent<Animation_Movement>();
                Animation_Movement move_screw = screw.GetComponent<Animation_Movement>();
                Animation_Movement move_nut = nut.GetComponent<Animation_Movement>();
                Animation_Movement move_bar = bar.GetComponent<Animation_Movement>();
               
                

                // Test_Highlight Box
                light_1.Light_Box_Blink();
                light_2.Light_Box_Blink();
                light_3.Light_Box_Blink();
                light_4.Light_Box_Blink();
                light_5.Light_Box_Blink();
                light_6.Light_Box_Blink();
                light_7.Light_Box_Blink();
                light_8.Light_Box_Blink();
                light_9.Light_Box_Blink();
                light_10.Light_Box_Blink();
                light_11.Light_Box_Blink(); 
                light_12.Light_Box();




                 move_cover_1.Move_x_left();
                 move_cover_2.Move_x_left();
                 move_holder_1.Move_x_left();
                 move_holder_2.Move_x_left();
                 move_nut.Move_x_left();
                 move_bar.Move_x_left();
               


                if (anchor)
                {
                    // Remember the anchor so we can remove it later.
                    m_Anchors.Add(anchor);
                }
                else
                {
                    Logger.Log("Error creating anchor");
                }
            }
           
        }

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        List<ARAnchor> m_Anchors = new List<ARAnchor>();

        ARRaycastManager m_RaycastManager;

        ARAnchorManager m_AnchorManager;
    }
}
