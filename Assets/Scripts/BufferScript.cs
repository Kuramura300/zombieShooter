using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferScript : MonoBehaviour
{
    GameObject Buffer;

    void Start()
    {

    }

    void Update()
    {
        if (Buffer != null)
        {
            GetComponent<HurtTrigger>().inspired = true;
        }
        else
        {
            GetComponent<HurtTrigger>().inspired = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BuffArea")
        {
            Buffer = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BuffArea")
        {
            Buffer = null;
        }
    }
}
