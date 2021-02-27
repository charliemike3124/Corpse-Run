using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWeight : MonoBehaviour
{
    const string PLAYER_TAG = "Player";

    public float killTreshold; 

    Rigidbody RB;

    void Start()
    {
        RB = GetComponent<Rigidbody>();        
    }



    void OnCollisionEnter(Collision c)
    {

        if (c.transform.tag == PLAYER_TAG)
        {
            PlayerManager player = c.transform.GetComponent<PlayerManager>();

            float WeightValue = RB.velocity.magnitude + c.relativeVelocity.magnitude;

            if (WeightValue >= killTreshold && 
                RB.velocity.magnitude > player.GetComponent<Rigidbody>().velocity.magnitude)
            { 
                player.die();
            }
        }
    }
}
