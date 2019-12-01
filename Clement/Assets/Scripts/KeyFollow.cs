using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFollow : MonoBehaviour {

    public Vector3 offset;
    public float smoothSpeed = 0.2f;
    GameObject target;
    PlayerController controller;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        controller = target.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(!controller.hasKey)
        {
            Destroy(gameObject);
        }

        if(target.transform.localScale == new Vector3(-1, 1, 1))
        {
            offset = new Vector3(1, 1, 0);
        }
        else
        {
            offset = new Vector3(-1, 1, 0);
        }

        if(controller.isRewinding)
        {
            offset = new Vector3(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
    }
}
