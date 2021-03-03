using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : TriggerEvent
{
    public GameObject fireEffect;
    public GameObject checkpointText;

    public override void OnTriggerEvent (GameObject triggerer, GameObject triggeredObject)
    {
        GameManager.Instance._chekpointPos = this.transform.parent.transform.position;
        fireEffect.SetActive(true);
        AudioManager.Instance.play("Bonfire");
        if (!GameManager.Instance.checkpoint)
        {
            GameManager.Instance.checkpoint = true;
            GameObject text = Instantiate(checkpointText, transform.position + Vector3.up, checkpointText.transform.rotation);
            Destroy(text, 2);
        }
    }
}
