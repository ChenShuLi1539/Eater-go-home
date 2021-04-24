using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEndPoint : MonoBehaviour
{
    public GameObject passPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            passPanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
