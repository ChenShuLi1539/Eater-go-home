using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    public float targetMass = 1.0f;
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
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 99f, ForceMode2D.Impulse);
            }
        }
    }
}
