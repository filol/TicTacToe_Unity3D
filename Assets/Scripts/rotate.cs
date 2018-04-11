using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    public Vector3 Rotation;

    private Vector3 _rotationVector;

    void Start()
    {
        _rotationVector = Vector3.zero;
    }

    void Update()
    {
        _rotationVector.x = Rotation.x * Time.deltaTime;
        _rotationVector.y = Rotation.y * Time.deltaTime;
        _rotationVector.z = Rotation.z * Time.deltaTime;
        transform.Rotate(_rotationVector);
    }
}
