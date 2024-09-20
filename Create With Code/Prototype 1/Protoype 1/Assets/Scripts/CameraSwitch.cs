using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;
    public KeyCode switchKey;

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonCamera.enabled = true;
        firstPersonCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(switchKey))
        {
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
            firstPersonCamera.enabled = !firstPersonCamera.enabled;
        }
    }
}
