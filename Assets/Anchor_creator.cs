using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
namespace UnityEngine.XR.ARFoundation.Samples
{

    public class Anchor_creator : MonoBehaviour
    {
        private Vector3 position;
        public GameObject content;
        // Update is called once per frame
        void Update()
        {
            content = GameObject.Find("HAP_Boxes");
            if (content.scene.IsValid())
            {
                position = content.transform.position;
                AnchorContent(position, content);
            }
            else
            {
                Debug.Log("not instanced yet");
            }
        }

        public void AnchorContent(Vector3 position, GameObject content)
        {
            content.AddComponent<ARAnchor>();
        }
    }
}