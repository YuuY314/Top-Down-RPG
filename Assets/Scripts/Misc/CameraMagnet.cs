using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMagnet : MonoBehaviour
{
    public GameObject magnetPosition;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            Camera.main.GetComponent<CameraBehaviour>().targetObject = magnetPosition;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            Camera.main.GetComponent<CameraBehaviour>().targetObject = collision.gameObject;
        }
    }
}
