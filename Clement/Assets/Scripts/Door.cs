using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    PlayerController controller;
    GameObject player;
    public bool locked;
    public SpriteRenderer sprite;
    public Sprite lockedSprite;
    public Sprite openSprite;

    public Vector2 loadPos;

    public string scene;
	
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<PlayerController>();
        locked = (PlayerPrefs.GetInt("state") != 0);
    }

	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance <= 1)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(!locked)
                {
                    player.transform.position = loadPos;
                    controller.positions.Clear();
                    SceneManager.LoadScene(scene);
                }
                else
                {
                    if(controller.hasKey)
                    {
                        locked = false;
                        controller.hasKey = false;
                    }
                }
            }
        }

        if(locked)
        {
            sprite.sprite = lockedSprite;
        } 
        else
        {
            sprite.sprite = openSprite;
        }
        PlayerPrefs.SetInt("state", (locked ? 1 : 0));
    }
}
