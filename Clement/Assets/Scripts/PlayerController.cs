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

    private bool isGrounded;
    public Transform feetPos;
    public float cheakRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private Animator anim;

	// Use this for initialization
	void Start () {
        positions = new List<Vector2>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, cheakRadius, whatIsGround);

        if(!isRewinding)
        {
            if (Input.GetKey(left))
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            else if (Input.GetKey(right))
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (Input.GetKey(jump) && isGrounded)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            if(Input.GetKey(jump) && isJumping)
            {
                if(jumpTimeCounter > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if(Input.GetKeyUp(jump))
            {
                isJumping = false;
            }
        }

        if(Input.GetMouseButton(1))
        {
            isRewinding = true;
        }
        else
        {
            isRewinding = false;
        }

        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", isGrounded);
        anim.SetBool("IsRewinding", isRewinding);
	}

    void FixedUpdate()
    {
        if(isRewinding)
        {
            rb.isKinematic = true;
            Time.timeScale = 2;
            Rewind();
        }
        else
        {
            rb.isKinematic = false;
            Time.timeScale = 1;
            Record();
        }
    }

    void Rewind()
    {
        if(positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
            rb.velocity = new Vector2(0, 0);
        }
    }

    void Record()
    {
        positions.Insert(0, transform.position);
    }
}
