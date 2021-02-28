using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [Header("Death")]
    public GameObject onDeathEffect;
    public float restartTime;
    public float yPosDeath;
    public float deathKnockbackForce;
    public bool isDead;

    void Update()
    {
        if (deathConditions()) StartCoroutine(die());
    }


    public IEnumerator die(bool leaveCorpse = false)
    {
        if (!isDead)
        {
            isDead = true;
            Instantiate(onDeathEffect, transform.position, onDeathEffect.transform.rotation);
            if (leaveCorpse)
            {
                foreach (Tween t in GetComponent<PlayerMovement>().tweens)
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
            GameObject newPlayer = Instantiate(GameManager.Instance.playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            GameManager.Instance.player = newPlayer.GetComponent<PlayerManager>();
            var scriptsNew = newPlayer.GetComponents<MonoBehaviour>().ToList();
            var scriptsChildrenNew = newPlayer.GetComponentsInChildren<MonoBehaviour>().ToList();
            scriptsNew.AddRange(scriptsChildrenNew);
            foreach (var script in scriptsNew)
            {
                script.enabled = true;
            }
            newPlayer.GetComponent<Rigidbody>().constraints
                = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
            Camera.main.GetComponent<CameraController>().cameraTarget = newPlayer.transform;
            if (!leaveCorpse)
            {
                Destroy(gameObject);
            }
        }
    }

    private bool deathConditions()
    {
        var condition = false;
        if (!isDead)
        {
            if (transform.position.y <= yPosDeath)
            {
                condition = true;
            }
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
