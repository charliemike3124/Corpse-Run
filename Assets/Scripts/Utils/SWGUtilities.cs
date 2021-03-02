using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWGUtilities : MonoBehaviour
{
    public static SWGUtilities Instance;
    void Awake()
    {
        Instance = Instance == null ? this : null;
    }

    public void ExecuteAfterTime(Action action, float time)
    {
        StartCoroutine(IExecuteAfterTime(action, time));
    }

    public IEnumerator IExecuteAfterTime(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }
}
