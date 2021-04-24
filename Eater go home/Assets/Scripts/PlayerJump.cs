using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public float jumpVelocity = 10f;
    public float failMultiplier = 2.5f;
    private Rigidbody2D rigidbody2D;
    private bool jumpRequest = false;
    private bool ground = false;

    public float boxHeight;
    private Vector2 playerSize;
    private Vector2 boxSize;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<SpriteRenderer>().bounds.size;
        boxSize = new Vector2(playerSize.x * 0.4f, boxHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && ground)
        {
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            rigidbody2D.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
        }
        else
        {
            Vector2 boxCenter = (Vector2)transform.position - (Vector2.up * playerSize * 0.5f);
            if (Physics2D.OverlapBox(boxCenter,boxSize,0,mask)!= null)
            {
                ground = true;
            }
            else
            {
                ground = false;
            }
        }
        if (rigidbody2D.velocity.y < 0)
        {
            rigidbody2D.gravityScale = failMultiplier;
        }
        else
        {
            rigidbody2D.gravityScale = 1f;
        }
    }
}
