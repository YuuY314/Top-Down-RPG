using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject playerObject;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        targetObject = playerObject;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(this.transform.position, new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, -10), 1 * Time.fixedDeltaTime);
    }
}
