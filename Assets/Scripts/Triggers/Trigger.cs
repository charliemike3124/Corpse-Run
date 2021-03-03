using UnityEngine;

public class Trigger : MonoBehaviour
{
    public enum TriggerType { Trigger, Collision};
    public TriggerType triggerType;
    public TriggerEvent trigger;
    public int triggerTimes;
    public bool canCorpseTrigger = true;

    private bool isTriggered;


    void OnTriggerEnter(Collider c)
    {
        if(triggerType == TriggerType.Trigger && triggerTimes > 0 && !isTriggered && triggerConditions(c))
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
        if (triggerType == TriggerType.Collision && triggerTimes > 0 && !isTriggered && triggerConditions(c)) 
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

    bool triggerConditions(Collision c )
    {
        bool condition = false;
        if(c.gameObject.layer != 1)
        {
            condition = true;
        }
        return condition;
    }
    bool triggerConditions(Collider c)
    {
        bool condition = true;

        if (!canCorpseTrigger)  condition = c.GetComponent<PlayerManager>().isDead? false : true;
        if (c.gameObject.layer == 1)    condition = false;

        return condition;
    }
}
