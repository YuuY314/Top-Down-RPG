using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject targetObject;
    private Vector3 targetTransform;
    public GameObject playerObject;
    public List<Transform> bondaries;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        targetObject = playerObject;
    }

    void FixedUpdate()
    {
        if((playerObject.transform.position.x < bondaries[0].position.x || playerObject.transform.position.x > bondaries[1].position.x) && (playerObject.transform.position.y < bondaries[2].position.y || playerObject.transform.position.y > bondaries[3].position.y)){
            targetTransform = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        } else if(playerObject.transform.position.x < bondaries[0].position.x || playerObject.transform.position.x > bondaries[1].position.x){
            targetTransform = new Vector3(gameObject.transform.position.x, targetObject.transform.position.y, -10);
        } else if(playerObject.transform.position.y < bondaries[2].position.y || playerObject.transform.position.y > bondaries[3].position.y){
            targetTransform = new Vector3(targetObject.transform.position.x, gameObject.transform.position.y, -10);
        } else {
            targetTransform = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, -10);
        }

        transform.position = Vector3.Lerp(this.transform.position, new Vector3(targetTransform.x, targetTransform.y, -10), 1 * Time.fixedDeltaTime);
    }
}
