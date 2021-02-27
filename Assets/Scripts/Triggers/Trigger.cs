using UnityEngine;

public class Trigger : MonoBehaviour
{
    public enum TriggerType { Trigger, Collision};
    public TriggerType triggerType;
    public TriggerEvent trigger;
    public int triggerTimes;

    private bool isTriggered;

    void OnTriggerEnter(Collider c)
    {
        if(triggerType == TriggerType.Trigger && triggerTimes > 0 && !isTriggered)
        {
            isTriggered = true;
            triggerTimes -= 1;
            trigger.OnTriggerEvent(c.gameObject, gameObject);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (isTriggered)
        {
            isTriggered = false;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (triggerType == TriggerType.Collision && triggerTimes > 0 && !isTriggered)
        {
            isTriggered = true;
            triggerTimes -= 1;
            trigger.OnTriggerEvent(c.gameObject, gameObject);
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (isTriggered)
        {
            isTriggered = false;
        }
    }
}
