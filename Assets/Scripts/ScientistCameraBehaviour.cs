using UnityEngine;
using System.Collections;

using Globals;
public class ScientistCameraBehaviour : MonoBehaviour {

    public GameObject TargetIndicator;
    public Camera PlayerCamera;
    public Transform TargerIndSmoother;

    public GameObject TargetObject;
    private Rigidbody _targetRigidBody;
    private CharacterJoint _targetJoint;

    public float MaxInteractionDistance = 10000;
    public LayerMask WhatToInteract;
    public bool IsHit;
    public bool IsGrabbing;
    
    public Vector3 hitPoint;
    public Vector3 distVect;
    public float distance;

    public float WheelMultiplier;


    //TODO are we locking cursor on start?
    void Awake()
    {

        _targetRigidBody = TargetIndicator.GetComponent<Rigidbody>();
        _targetJoint = TargetIndicator.GetComponent<CharacterJoint>();
    }


    void Update()
    {

        //todo raycast her zaman olucak. elde birsey yokken el havaya kalkma animasyonu olucak

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
        TargerIndSmoother.position = hitPoint;

        //attach joint here!
        //var hj = TargetObject.AddComponent<HingeJoint>();
        //hj.connectedBody = _targetRigidBody;
        _targetJoint.connectedBody = TargetObject.GetComponent<Rigidbody>();
        _targetJoint.connectedAnchor = Vector3.zero;
        //Grabbed!
        while (Input.GetButton(PlayerInput.Use))
        {
            //Debug.Log("Physicing " + TargetObject.name);

            //then we handle scroll lock delta
            //Input.mouseScrollDelta
            //TargetIndicator.transform.position = transform.position + distVect;
            distance = distVect.magnitude;
            TargerIndSmoother.Translate(Vector3.forward * Input.GetAxis(PlayerInput.MouseWheel) * WheelMultiplier);
            if (Input.GetAxis(PlayerInput.MouseWheel) != 0)
            {
                Debug.Log("scrolled " + Input.GetAxis(PlayerInput.MouseWheel));
            }

            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Grap Ended");

        //Detach joint 
        //Destroy(hj); //ToDo what is that??? bunu niye yapıyomki şimdi ben.
        _targetJoint.connectedBody = null;

        //disable target
        TargetIndicator.SetActive(false);


        IsGrabbing = false;
        yield break;
    }





}
