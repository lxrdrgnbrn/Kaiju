using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private bool a= false;
    void Start()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MyPlayer")
        {
            Destroy(gameObject);
            a = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
