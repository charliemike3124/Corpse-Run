using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour
{
    public float time;
    void Start()
    {
        Invoke("DestroySelf", time);
    }
    
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
