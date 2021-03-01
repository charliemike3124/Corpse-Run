using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : TriggerEvent {

    public override void OnTriggerEvent (GameObject triggerer, GameObject triggeredObject)
    {
        // instantiate PE
        GameManager.Instance.EndGame();
    }
}


