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
    
    public Vector3 hitPoint;
    public Vector3 distVect;
    public float distance;

    //TODO are we locking cursor on start?


    void Update()
    {


        #region Camera Interaction AKA use button interactivity
        if (Input.GetButtonDown(PlayerInput.Use) && (!IsGrabbing))
        {
            Debug.Log("Pressed Use, not grabbing now(obviously), Raycasting.");
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
                Debug.Log("Its an hit!");
                TargetObject = hit.transform.gameObject;
                hitPoint = hit.point;
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

        //enable target
        TargetIndicator.SetActive(true);
        TargetIndicator.transform.position = hitPoint;

        //attach joint here!
        //get distance
        distVect = hitPoint - transform.position;
        
        //Grabbed!
        while (Input.GetButton(PlayerInput.Use))
        {
            Debug.Log("Physicing " + TargetObject.name);

            //then we handle scroll lock delta
            //Input.mouseScrollDelta
            //TargetIndicator.transform.position = transform.position + distVect;
            distance = distVect.magnitude; 

            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Grap Ended");

        //Detach joint 

        //disable target
        TargetIndicator.SetActive(false);


        IsGrabbing = false;
        yield break;
    }





}
