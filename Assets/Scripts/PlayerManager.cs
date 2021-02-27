using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject onDeathEffect;
    public float yPosDeath;

    void Update()
    {
        if (deathConditions()) die();
    }


    public void die()
    {
        Instantiate(onDeathEffect, transform.position, onDeathEffect.transform.rotation);
        GameManager.Instance.RestartSceneAfterSeconds(1.5f);
        Destroy(gameObject);
    }

    private bool deathConditions()
    {
        var condition = false;
        if(transform.position.y <= yPosDeath)
        {
            condition = true;
        }
        return condition;
    }

}
