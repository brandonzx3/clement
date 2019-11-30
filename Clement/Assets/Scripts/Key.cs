using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public PlayerController controller;
	
	void OnTriggerEnter2D(Collider2D col)
    {
        controller.hasKey = true;
        Destroy(gameObject);
    }
}
