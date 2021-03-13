using UnityEngine;

public class Trigger : MonoBehaviour
{
    public enum TriggerType { Trigger, Collision};
    public TriggerType triggerType;
    public TriggerEvent trigger;
    public int triggerTimes;
    public bool inifniteTriggerTimes;
    public bool canCorpseTrigger = true;

    private bool isTriggered;


    void OnTriggerEnter(Collider c)
    {
        if(triggerType == TriggerType.Trigger && triggerConditions(c))
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
            trigger.OnTriggerExitEvent(c.gameObject, gameObject);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (triggerType == TriggerType.Collision && triggerConditions(c)) 
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
            trigger.OnTriggerExitEvent(c.gameObject, gameObject);
        }
    }

    #region Helpers
    bool triggerConditions(Collision c )
    {
        bool condition = true;
        if (!canCorpseTrigger) condition = c.transform.GetComponent<PlayerManager>().isDead ? false : true;
        if (isTriggered) condition = false;
        if (triggerTimes == 0 && !inifniteTriggerTimes) condition = false;
        if (c.gameObject.layer == 1) condition = false;

        return condition;
    }
    bool triggerConditions(Collider c)
    {
        bool condition = true;
        if (!canCorpseTrigger) condition = c.GetComponent<PlayerManager>()?.isDead ?? false ? false : true;
        if (isTriggered) condition = false;
        if (triggerTimes == 0 && !inifniteTriggerTimes) condition = false;
        if (c.gameObject.layer == 1) condition = false;

        return condition;
    }
    #endregion
}
