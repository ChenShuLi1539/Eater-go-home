using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 10.0f;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float x;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");


        if (x > 0)
        {
            rigidbody2D.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("run", true);
        }
        if (x < 0)
        {
            rigidbody2D.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            animator.SetBool("run", true);
        }
        if (x<0.001f && x > -0.001f)
        {
            animator.SetBool("run", false);
        }
        Run();
    }

    private void Run()
    {
        if (x > 0) rigidbody2D.AddForce(Vector2.right * force);
        if (x < 0) rigidbody2D.AddForce(Vector2.left * force);
        if (x < 0.001f && x > -0.001f) rigidbody2D.AddForce(new Vector2(0,0));
    }
}
