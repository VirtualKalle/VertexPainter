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
    [SerializeField, Range(0, 1)] float rotationSpeed; 
    [SerializeField, Range(0, 1)] float zoomSpeed;


    void OnGUI()
    {

        #region moveGO

        // Zooming
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Camera.transform.Translate((new Vector3(0, 0, -1)) * 0.1f * zoomSpeed, Space.World);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Camera.transform.Translate((new Vector3(0, 0, 1)) * 0.1f * zoomSpeed, Space.World);
        }

        // Rotating
        if (Input.GetMouseButton(1))
        {
            paintObject.transform.Rotate((new Vector3(0, -1, 0)) * rotationSpeed * Input.GetAxis("Mouse X"), Space.World);
            paintObject.transform.Rotate((new Vector3(1, 0, 0)) * rotationSpeed * Input.GetAxis("Mouse Y"), Space.World);
        }

        // Translating
        else if (Input.GetMouseButton(2))
        {
            paintObject.transform.Translate((new Vector3(1, 0, 0)) * 0.1f * translateSpeed * Input.GetAxis("Mouse X"), Space.World);
            paintObject.transform.Translate((new Vector3(0, 1, 0)) * 0.1f * translateSpeed * Input.GetAxis("Mouse Y"), Space.World);
        }

        #endregion

    }

}


