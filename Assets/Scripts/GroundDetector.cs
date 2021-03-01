using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isGrounded;
    public PhysicMaterial noFrictionMat;

    private PlayerMovement PM;
    private PhysicMaterial originalMat;

    void Start()
    {
        PM = GetComponentInParent<PlayerMovement>();
        originalMat = PM.GetComponent<Collider>().material;
    }

    void OnTriggerStay(Collider c)
    {
        isGrounded = true;

        if (!GetComponentInParent<PlayerManager>().isDead)
        {
            PM.GetComponent<Collider>().material = originalMat;
        }
    }

    void OnTriggerExit(Collider c)
    {
        isGrounded = false;
        PM.GetComponent<Collider>().material = noFrictionMat;

    }
}
