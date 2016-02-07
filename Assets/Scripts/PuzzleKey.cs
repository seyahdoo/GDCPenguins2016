using UnityEngine;
using System.Collections;

public class PuzzleKey : MonoBehaviour {

    public enum KeyTypes
    {
        Cpu = 0,
        Usb,
        Pipe,
        Wires,
        Display,
        PowerSupply,
        Motherboard
    }

    public KeyTypes Type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
