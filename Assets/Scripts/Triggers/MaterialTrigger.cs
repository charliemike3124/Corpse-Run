using System.Linq;
using UnityEngine;

public class MaterialTrigger : TriggerEvent
{
    public override void OnTriggerEvent(GameObject triggerer, GameObject triggeredObject)
    {
        if(triggerer.tag == "Ground")
        {
            triggerer.GetComponent<Collider>().material = Resources.Instance.materials.PhysicMaterials[0];
        }
    }

    public override void OnTriggerExitEvent(GameObject triggerer, GameObject triggeredObject)
    {
        if (triggerer.tag == "Ground")
        {
            triggerer.GetComponent<Collider>().material = Resources.Instance.materials.PhysicMaterials[3];
        }
    }
}
