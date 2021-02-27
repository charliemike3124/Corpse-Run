using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isGrounded;

    private PlayerMovement PM;

    void Start()
    {
        PM = GetComponentInParent<PlayerMovement>();
    }

    void OnTriggerStay(Collider c)
    {
        isGrounded = true; 
    }

    void OnTriggerExit(Collider c)
    {
        isGrounded = false;

    }
}
