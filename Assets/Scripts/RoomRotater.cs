using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomRotater : MonoBehaviour
{
    private static RoomRotater _instance;
    public PlayerInputController PlayerIC;
    public Transform PlayerPos;
    public float ForceMultiplier;

    private bool _ready;
    private List<Rigidbody> _objects;

    public static RoomRotater Instance
    {
        get { return _instance; }
    }

    // Use this for initialization
	void Start ()
	{
	    _instance = this;
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

	    float rad = PlayerIC.MouseDelta.x * Mathf.Deg2Rad;
        //Debug.Log(rad);
	    if (Mathf.Abs(rad) <= 0.2f)
	    {
	        return;
	    }

	    foreach (Rigidbody o in _objects)
	    {
            //move
            Vector3 movementVector = Vector3.zero;

            //rotate
	        Vector3 vec = o.position - PlayerPos.position;
	        vec.y = 0f;
            Vector3 vec90Deg = Quaternion.AngleAxis(rad > 0 ? -1 * 90 : 1 * 90, Vector3.up) * vec;
	        vec90Deg += movementVector;
            Debug.DrawRay(o.position, vec90Deg, Color.red, 0.01f);
            o.AddForce(vec90Deg * ForceMultiplier,ForceMode.Impulse);
	    }
        
	}

    private IEnumerator ReadyAfterSecs(float s)
    {
        yield return new WaitForSeconds(s);
        _ready = true;
    }

    public void RemoveTagFromObj(Rigidbody removeObj)
    {
        removeObj.tag = "temp";
        _objects.Remove(removeObj);
    }

    public void AddTagToObj(Rigidbody addObj)
    {
        addObj.tag = "objs";
        _objects.Add(addObj);
    }
}
