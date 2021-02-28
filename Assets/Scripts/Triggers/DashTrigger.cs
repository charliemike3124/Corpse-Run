using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrigger : TriggerEvent
{
    public GameObject PE_Dash_Text;

    public override void OnTriggerEvent(GameObject triggerer, GameObject triggeredObject)
    {
        GameObject text = Instantiate(PE_Dash_Text, transform.position, PE_Dash_Text.transform.rotation);
        Destroy(text, 4);
    }
}
