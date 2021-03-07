using UnityEngine;
using System.Collections;


namespace RPG
{
    public class CameraFollow : MonoBehaviour
    {

        //References the Player object
        public Transform Target;
        public float camSpeed = 0.3f;
        public float camZoom = 1; // field of view
        Camera mainCam;

        GameObject Player;


        private void Awake()
        {
            // Application.targetFrameRate = 60;
        }
        // Use this for initialization
        void Start()
        {
            mainCam = GetComponent<Camera>();
            // Target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // LateUpdate is called after updating each frame
        void Update()
        {
            // mainCam.orthographicSize = (Screen.height / 100f) / 0.8f;

            if (Target)
            {
                mainCam.transform.position = Vector3.Lerp(transform.position, Target.position, camSpeed) + new Vector3(0, 0, -30);
                mainCam.fieldOfView = 50 * camZoom;
            }
            // else
            // {
            //     Debug.Log("no target");
            // }
        }
    }
}