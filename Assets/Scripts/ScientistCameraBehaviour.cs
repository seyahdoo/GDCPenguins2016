using UnityEngine;
using System.Collections;

using Globals;
public class ScientistCameraBehaviour : MonoBehaviour {



    public GameObject TargetObject;

    public Camera PlayerCamera;


    public float MaxInteractionDistance = 10000;
    public LayerMask WhatToInteract;
    public bool isHit;


    public bool orbit;

    
    //TODO are we locking cursor on start?


    void Update()
    {

        #region Cursor Locking
        //handle cursor locking
        //if (Input.GetButtonDown(PlayerInput.CameraLock))
        //{
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
        //
        //if (Input.GetButtonDown(PlayerInput.CameraUnlock))
        //{
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.None; /// TODO maybe .Confined
        //}
        #endregion

        #region Camera Rotation
        //handle camera rotation!
        //code here

        //calculate x delta movement
        //calculate y delta movement

        



        #endregion

        #region Camera Interaction AKA use button interactivity
        //interact from camera!
        Ray ray = PlayerCamera.ScreenPointToRay(
            new Vector3(
                Screen.width * 0.5f, 
                Screen.height * 0.5f,
                0f
            ));
        RaycastHit hit;

        isHit = Physics.Raycast(ray.origin, ray.direction, out hit, MaxInteractionDistance, WhatToInteract);

        if (isHit)
        {
        TargetObject = hit.transform.gameObject;
        TargetObject.name = "asdasd";
        }
        #endregion

    }





}
