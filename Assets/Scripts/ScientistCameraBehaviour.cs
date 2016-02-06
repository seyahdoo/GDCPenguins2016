using UnityEngine;
using System.Collections;

using Globals;
public class ScientistCameraBehaviour : MonoBehaviour {




    public GameObject TargetIndicator;
    public Camera PlayerCamera;

    public GameObject TargetObject;

    public float MaxInteractionDistance = 10000;
    public LayerMask WhatToInteract;
    public bool IsHit;
    public bool IsGrabbing;

    
    
    //TODO are we locking cursor on start?


    void Update()
    {

        #region Cursor Locking
        //handle cursor locking
        if (Input.GetButtonDown(PlayerInput.CameraLock))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        if (Input.GetButtonDown(PlayerInput.CameraUnlock))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; /// TODO maybe .Confined
        }
        #endregion

        #region Camera Rotation
        //handle camera rotation!
        //code here

        //calculate x delta movement
        //calculate y delta movement





        #endregion

        if (Input.GetButtonDown(PlayerInput.Use))
        {
            Debug.Log("asdsad");
        }


        #region Camera Interaction AKA use button interactivity
        if (Input.GetButtonDown(PlayerInput.Use) && (!IsGrabbing))
        {
            //interact from camera!
            Ray ray = PlayerCamera.ScreenPointToRay(
                new Vector3(
                    Screen.width * 0.5f,
                    Screen.height * 0.5f,
                    0f
                ));
            RaycastHit hit;

            IsHit = Physics.Raycast(ray.origin, ray.direction, out hit, MaxInteractionDistance, WhatToInteract);

            if (IsHit)
            {
                TargetObject = hit.transform.gameObject;
                //TargetObject.name = "asdasd";
                //TargetObject.SetActive(false);
                StartCoroutine(Grabbing());
            }

        }
        
        #endregion

    }


    public IEnumerator Grabbing()
    {
        if (TargetObject == null)
        {
            yield break;
        }
        IsGrabbing = true;
        Debug.Log("Grabbed! " + TargetObject.name);
        //Grabbed!
        while (Input.GetButton(PlayerInput.Use))
        {
            Debug.Log("Physicing " + TargetObject.name);
            yield return new WaitForEndOfFrame();
        }
        
        IsGrabbing = false;
        yield break;
    }





}
