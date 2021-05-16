using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Follow")] 
    public float cameraFollowSpeed; 
    public Vector3 _cameraOffset;
     

    [Header("Dependencies")]
    public Transform cameraTarget; 
         
    void FixedUpdate()
    {
        if (cameraTarget != null)
        {
            var targetPos = new Vector3(cameraTarget.position.x + _cameraOffset.x, cameraTarget.position.y + _cameraOffset.y, cameraTarget.position.z + _cameraOffset.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, cameraFollowSpeed);  

            //transform.eulerAngles = new Vector3(cameraTarget.eulerAngles.x, transform.eulerAngles.y, cameraTarget.eulerAngles.z);
        }

    }   
}
