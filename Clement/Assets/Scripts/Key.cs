using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public PlayerController controller;
    public GameObject keyFollow;
	
	void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(keyFollow, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        controller.hasKey = true;
        Destroy(gameObject);
    }
}
