using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjectScript : MonoBehaviour {
    [SerializeField]
    private float RotationSpeed;
    [SerializeField]
    private float RotationAngle;
    private bool isRotating = false;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Rotate();
            isRotating = true;
        }
    }

    void Rotate()
    {
        if (isRotating)
        {
            RotationAngle = Mathf.PingPong(Time.time * RotationSpeed, 140) - 70;
            transform.rotation = Quaternion.Euler(0, 0, RotationAngle);
        }
    }
}
