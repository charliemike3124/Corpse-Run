
using UnityEngine;

public class TankTrigger : TriggerEvent
{
    public Tank _tank; 
    public override void OnTriggerEvent (GameObject triggerer, GameObject triggeredObject)
    {

      Debug.Log(triggerer.tag);   
      if(triggerer.tag == "Player"){
        (_tank as Enemy)._targetPlayer = triggerer.transform; 
        Debug.Log("Hello"); 
      }  
    }
}
