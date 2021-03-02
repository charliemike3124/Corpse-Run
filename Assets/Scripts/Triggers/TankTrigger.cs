
using UnityEngine;

public class TankTrigger : TriggerEvent
{
    public Tank _tank; 
    public override void OnTriggerEvent (GameObject triggerer, GameObject triggeredObject)
    {
      if(triggerer.tag == "Player"){
        _tank._targetPlayer = triggerer.transform; 
      }  
    }
}
