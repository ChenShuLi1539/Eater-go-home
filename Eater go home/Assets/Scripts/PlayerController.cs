using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float force = 8.0f;
    public float consum = 0.2f;
    public float recover = 0.1f;
    public Slider energy;
    public float speed = 5f;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float x;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        energy.value = 1;
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
        Walk();
        if (energy.value > 0 && Input.GetKey("left shift"))
        {
            Run();
        }
        else
        {
            if (x < 0.001f && x > -0.001f)
            {
                animator.SetBool("run", false);   
            }
            energy.value += recover * Time.deltaTime;
        }
    }

    private void Walk()
    {
        Vector3 movement = new Vector3(x, 0, 0);
        rigidbody2D.transform.position += movement * speed * Time.deltaTime;
    }

    private void Run()
    {
        if (x > 0)
        {
            rigidbody2D.AddForce(Vector2.right * force);
            energy.value -= consum * Time.deltaTime;
        }
        if (x < 0)
        {
            rigidbody2D.AddForce(Vector2.left * force);
            energy.value -= consum * Time.deltaTime;
        }
        if (x < 0.001f && x > -0.001f)
        {
            rigidbody2D.AddForce(new Vector2(0, 0));
            energy.value += recover * Time.deltaTime;
        } 
    }
}
