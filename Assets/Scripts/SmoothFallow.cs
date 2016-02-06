using UnityEngine;
using System.Collections;

public class SmoothFallow : MonoBehaviour {

    public Transform whereCameraShouldBe;
    public Transform _transform;
    public float cameraSmoothSpeed = 0.2f;

    void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        _transform.position = Vector3.Lerp(transform.position, whereCameraShouldBe.position, cameraSmoothSpeed);
        _transform.rotation = Quaternion.Slerp(transform.rotation, whereCameraShouldBe.rotation, cameraSmoothSpeed);
    }
}
