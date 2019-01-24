using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] GameObject paintObject;
    [SerializeField] GameObject Camera;

    [SerializeField] KeyCode RightKey;
    [SerializeField] KeyCode LeftKey;
    [SerializeField] KeyCode UpKey;
    [SerializeField] KeyCode DownKey;
    [SerializeField, Range(0, 1)] float translateSpeed;
    [SerializeField, Range(0, 1)] float rotationSpeed = 1; 
    [SerializeField, Range(0, 1)] float zoomSpeed = 1;


    void OnGUI()
    {
      
        #region moveGO
        
        // Rotating
        if (Input.GetKey("q"))
        {

            if (Input.GetKey(RightKey))
            {
                paintObject.transform.Rotate((new Vector3(0, 1, 0)) * rotationSpeed, Space.World);
            }
            else if (Input.GetKey(LeftKey))
            {
                paintObject.transform.Rotate((new Vector3(0, -1, 0)) * rotationSpeed, Space.World);
            }

            else if (Input.GetKey(UpKey))
            {
                paintObject.transform.Rotate((new Vector3(1, 0, 0)) * rotationSpeed, Space.World);
            }


            else if (Input.GetKey(DownKey))
            {
                paintObject.transform.Rotate((new Vector3(-1, 0, 0)) * rotationSpeed, Space.World);
            }

        }

        // Zooming
        else if (Input.GetKey("e"))
        {
            if (Input.GetKey(DownKey))
            {
                Camera.transform.Translate((new Vector3(0, 0, -1)) * 0.1f * zoomSpeed, Space.World);
            }
            else if (Input.GetKey(UpKey))
            {
                Camera.transform.Translate((new Vector3(0, 0, 1)) * 0.1f * zoomSpeed, Space.World); ;
            }
        }

        // Translating
        else
        {
            if (Input.GetKey(RightKey))
            {
                paintObject.transform.Translate((new Vector3(1, 0, 0)) * 0.1f * translateSpeed, Space.World);
            }
            else if (Input.GetKey(LeftKey))
            {
                paintObject.transform.Translate((new Vector3(-1, 0, 0)) * 0.1f * translateSpeed, Space.World);
            }
            else if (Input.GetKey(UpKey))
            {
                paintObject.transform.Translate((new Vector3(0, 1, 0)) * 0.1f * translateSpeed, Space.World);
            }
            else if (Input.GetKey(DownKey))
            {
                paintObject.transform.Translate((new Vector3(0, -1, 0)) * 0.1f * translateSpeed, Space.World);
            }

        }
        
        #endregion

    }

}


