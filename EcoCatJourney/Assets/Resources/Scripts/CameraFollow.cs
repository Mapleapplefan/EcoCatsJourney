using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(2, 10)]
    public float smoothFactor;
    public Vector3 minValue, maxValue;
    private void LateUpdate(){
        Follow();
        //transform.position= target.position + offset;
    }

    void Follow(){
        Vector3 targetPosition = target.position + offset;
        //Verify if the targetPosition is out of bounds or not
        //Limit to min and max values
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x), 
            Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),  transform.position.z  
        );

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;

    }

}
