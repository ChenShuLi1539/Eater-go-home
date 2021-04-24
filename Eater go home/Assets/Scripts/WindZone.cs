using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    public float targetMass = 1.0f;
    public string direction = "down";
    public float force = 99f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().mass < targetMass)
            {
                switch (direction)
                {
                    case "down": 
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * force, ForceMode2D.Impulse);
                        break;
                    case "up":
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
                        break;
                    case "left":
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force, ForceMode2D.Impulse);
                        break;
                    case "right":
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force, ForceMode2D.Impulse);
                        break;
                    default:
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * force, ForceMode2D.Impulse);
                        break;
                }
                
            }
        }
    }
}
