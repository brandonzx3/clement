using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject player;

    public Sprite open;
    public Sprite closed;

    public SpriteRenderer r;

    public bool opened = false;

	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance <= 1)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                opened = true;
            }
        }

        if(opened)
        {
            r.sprite = open;
        }
        else
        {
            r.sprite = closed;
        }
    }
}
