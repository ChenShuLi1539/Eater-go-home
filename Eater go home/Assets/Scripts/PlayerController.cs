using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float x;
    private float y;

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
        y = Input.GetAxis("Vertical");


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
        Vector3 movement = new Vector3(x, y, 0);
        rigidbody2D.transform.position += movement * speed * Time.deltaTime;
    }
}
