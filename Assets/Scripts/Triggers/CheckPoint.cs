using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : TriggerEvent
{
     public override void OnTriggerEvent (GameObject triggerer, GameObject triggeredObject)
    {
        GameManager.Instance._chekpointPos =   this.transform.parent.transform.position;  
    }
}
