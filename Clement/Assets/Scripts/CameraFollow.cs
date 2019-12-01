using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

	void FixedUpdate () {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
	}
}
