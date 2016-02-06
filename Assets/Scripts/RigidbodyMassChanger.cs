using UnityEngine;
using System.Collections;

public class RigidbodyMassChanger: MonoBehaviour
{

    public Rigidbody RigidB;
    public GameObject CenterOfMass;

	// Use this for initialization
	void Start ()
	{
        RigidB.centerOfMass = CenterOfMass.transform.localPosition;

	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
