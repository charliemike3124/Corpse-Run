using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject playerPrefab;

    [Header("Death")]
    public GameObject onDeathEffect;
    public float restartTime;
    public float yPosDeath;
    public float deathKnockbackForce;

    void Update()
    {
        if (deathConditions()) StartCoroutine(die());
    }


    public IEnumerator die(bool leaveCorpse = false)
    {
        Instantiate(onDeathEffect, transform.position, onDeathEffect.transform.rotation);
        if (!leaveCorpse)
        {
            Destroy(gameObject);
        }
        else
        {
            foreach(Tween t in GetComponent<PlayerMovement>().tweens)
            {
                t.Pause();
            }

            Camera.main.GetComponent<CameraController>().cameraTarget = null;
            var scripts = gameObject.GetComponents<MonoBehaviour>().ToList();
            var scriptsChildren = gameObject.GetComponentsInChildren<MonoBehaviour>().ToList();
            scripts.AddRange(scriptsChildren);
            foreach (var script in scripts)
            {
                script.enabled = false;
            }

            yield return new WaitForEndOfFrame();
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
            rb.AddForce(transform.right * -deathKnockbackForce);
        }

        yield return new WaitForSeconds(restartTime);
        GameObject newPlayer = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        var scriptsNew = newPlayer.GetComponents<MonoBehaviour>().ToList();
        var scriptsChildrenNew = newPlayer.GetComponentsInChildren<MonoBehaviour>().ToList();
        scriptsNew.AddRange(scriptsChildrenNew);
        foreach(var script in scriptsNew)
        {
            script.enabled = true;
        }
        newPlayer.GetComponent<Rigidbody>().constraints 
            = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
        Camera.main.GetComponent<CameraController>().cameraTarget = newPlayer.transform;
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

    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Enemy")
        {
            StartCoroutine(die(true));
        }
    }

}
