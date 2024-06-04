using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<EntityStats>().baseSpeed /= 2;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<EntityStats>().baseSpeed *= 2;
        }
    }
}
