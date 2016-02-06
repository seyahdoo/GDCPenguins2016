using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomRotater : MonoBehaviour
{

    public PlayerInputController PlayerIC;
    public Transform PlayerPos;
    private Rigidbody _rigidbody;    
    public float forceMultiplier;

    private bool _ready;
    private List<Rigidbody> _objects;

	// Use this for initialization
	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody>();        
	    StartCoroutine(ReadyAfterSecs(2f));
        _objects = new List<Rigidbody>();

	    GameObject[] gos = GameObject.FindGameObjectsWithTag("objs");

	    foreach (GameObject go in gos)
	    {
	        _objects.Add(go.GetComponent<Rigidbody>());
	    }

	}
	
	// Update is called once per frame
	void Update () {
	    if (!_ready)
	    {
	        return;
	    }
        //Vector3 pos = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.x);
        //
        //Vector3 torque = transform.up * Torque * -PlayerIC.MouseDelta.x;
	    //torque += pos;
	    ////Vector3 t2 = transform.right * Torque * PlayerIC.MouseDelta.y;
	    ////torque = torque + t2;
	    //_rigidbody.AddRelativeTorque(torque,ForceMode.Acceleration);

	    float rad = PlayerIC.MouseDelta.x * Mathf.Deg2Rad;
        Debug.Log(rad);
	    if (Mathf.Abs(rad) <= 0.2f)
	    {
	        return;
	    }

	    foreach (Rigidbody o in _objects)
	    {
	        Vector3 vec = o.position - PlayerPos.position;
            Vector3 vec90Deg = Quaternion.AngleAxis(rad > 0 ? -1 * 90 : 1 * 90, Vector3.up) * vec;
            Debug.DrawRay(o.position, vec90Deg, Color.red, 0.01f);

            o.AddForce(vec90Deg * forceMultiplier,ForceMode.VelocityChange);

            //float v = Mathf.Tan(rad) * vec.magnitude;
	    }
        
	}

    private IEnumerator ReadyAfterSecs(float s)
    {
        yield return new WaitForSeconds(s);
        _ready = true;
    }

    //private IEnumerator FSM()
    //{
    //    //PlayerIC.LookDir;
    //    //PlayerIC.MouseDelta;
    //    //PlayerIC.MoveDir
    //
    //    yield return new WaitForSeconds(0.26f);
    //}
}
