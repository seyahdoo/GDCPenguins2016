using UnityEngine;
using System.Collections;

public class FloorRotater : MonoBehaviour {
    public Transform Floor;
    private Rigidbody FloorRigidBody;
    public float Torque;
	// Use this for initialization
	void Start () {
        FloorRigidBody = Floor.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 torque = transform.up * Torque * Input.GetAxis("Horizontal");
        FloorRigidBody.AddTorque(torque, ForceMode.VelocityChange);

	}
}
