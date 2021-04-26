using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandPlatform : MonoBehaviour
{
    public GameObject standPlatform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            standPlatform.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
