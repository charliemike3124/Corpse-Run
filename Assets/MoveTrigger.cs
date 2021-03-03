using DG.Tweening;
using UnityEngine;

public class MoveTrigger : TriggerEvent
{
    public Vector3 moveValue;
    public float animDuration;

    public override void OnTriggerEvent(GameObject triggerer, GameObject triggeredObject)
    {
        transform.DOLocalMove(moveValue, animDuration).SetAutoKill();
        triggeredObject.transform.DOLocalMoveY(triggeredObject.transform.localPosition.y - 0.05f, 0.1f).OnComplete(() => {
            if (triggeredObject.GetComponent<Trigger>().triggerTimes > 0)
            {
                triggeredObject.transform.DOLocalMoveY(0, 0.1f);
            }
        });
        AudioManager.Instance.play("Trigger Trap");
    }
}
