using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : TriggerEvent {

    [SerializeField] private float _wait; 

    public override void OnTriggerEvent (GameObject triggerer, GameObject triggeredObject) {
        Invoke("Finish", _wait); 
    }

    private void Finish(){
        GameManager.Instance.EndGame ();
    }   
}


