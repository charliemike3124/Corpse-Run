using System.Linq;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public string[] jumpableTags;
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
        if(jumpableTags.Contains(c.tag))
        {
            isGrounded = true;

            if (!GetComponentInParent<PlayerManager>().isDead)
            {
                PM.GetComponent<Collider>().material = originalMat;
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (jumpableTags.Contains(c.tag))
        {
            isGrounded = false;
            PM.GetComponent<Collider>().material = noFrictionMat;
        }

    }    
}
