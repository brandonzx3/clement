using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public bool isRewinding = false;

    List<Vector2> positions;

	// Use this for initialization
	void Start () {
        positions = new List<Vector2>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if(Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(Input.GetKeyDown(jump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(Input.GetMouseButton(1))
        {
            isRewinding = true;
        }
        else
        {
            isRewinding = false;
        }
	}

    void FixedUpdate()
    {
        if(isRewinding)
        {
            rb.isKinematic = true;
            rb.gravityScale = 0;
            Rewind();
        }
        else
        {
            rb.isKinematic = false;
            rb.gravityScale = 1;
            Record();
        }
    }

    void Rewind()
    {
        if(positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
    }

    void Record()
    {
        positions.Insert(0, transform.position);
    }
}
