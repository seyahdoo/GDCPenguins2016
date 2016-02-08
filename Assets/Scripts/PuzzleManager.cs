using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    private static PuzzleManager _instance;
    public Transform PuzzleCase;
    public Transform CpuSlot;
    public Transform UsbsSlot;
    public Transform PipeSlot;
    public Transform DisplaySlot;
    public Transform PowerSupplySlot;
    public Transform MotherboardSlot;

    public Transform UI;

    private List<Transform> _keys;
    private int _successfullyPlacedKeys;
    private bool _puzzleSolved;

    public static PuzzleManager Instance
    {
        get { return _instance; }
    }

    public int SuccessfullyPlacedKeys
    {
        get { return _successfullyPlacedKeys; }
        set
        {
            _successfullyPlacedKeys = Mathf.Clamp(value, 0, _keys.Count);
            if (_successfullyPlacedKeys == _keys.Count)
            {
                _puzzleSolved = true;
                OnPuzzleSolved();
            }
        }
    }

    // Use this for initialization
	void Start ()
	{
	    _instance = this;
	    _successfullyPlacedKeys = 0;
	    _keys = new List<Transform>
	    {
	        CpuSlot,
	        UsbsSlot,
	        PipeSlot,
	        DisplaySlot,
	        PowerSupplySlot,
	        MotherboardSlot
	    };
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaceKey(Transform key)
    {
        PuzzleKey pk = key.gameObject.GetComponent<PuzzleKey>();
        if (pk == null)
        {
            Debug.LogError("wtf");
            return;
        }
        Debug.Log((int)pk.Type);
        Transform temp = _keys[(int) pk.Type];
        
        key.parent = temp;
        key.position = temp.position;
        key.rotation = temp.rotation;

        key.tag = "Untagged";
        Rigidbody rb = key.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.freezeRotation = true;

        _successfullyPlacedKeys++;
    }

    public void OnPuzzleSolved()
    {
        //todo
        UI.gameObject.SetActive(true);
        StartCoroutine(DelayedStart());
    }

    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Start");
    }
}
