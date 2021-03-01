using DG.Tweening;
using UnityEngine;

public class MoveTrigger : TriggerEvent
{
    public Vector3 moveValue;
    public float animDuration;

    public override void OnTriggerEvent(GameObject triggerer, GameObject triggeredObject)
    {
        transform.DOLocalMove(moveValue, animDuration).SetAutoKill();
        AudioManager.Instance.play("Trigger Trap");
    }
}
