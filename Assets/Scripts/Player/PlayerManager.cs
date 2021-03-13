using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool isBeingHeld;

    [Header("Death")]
    public string INTERACTABLE_TAG = "Interactable";
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
            AudioManager.Instance.play("Death");
            isDead = true;
            transform.tag = INTERACTABLE_TAG;
            if (leaveCorpse)
            {
                foreach (Tween t in GetComponent<PlayerMovement>().tweens)
                {
                    t.Pause();
                }
                enableScriptsAndComponents(false);
                yield return new WaitForEndOfFrame();
                addDeathPhysics();
            }

            yield return new WaitForSeconds(restartTime);
            GameObject newPlayer = Instantiate(GameManager.Instance.playerPrefab, GameManager.Instance._chekpointPos, Quaternion.identity);
            GameManager.Instance.player = newPlayer.GetComponent<PlayerManager>();
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
                Instantiate(onDeathEffect, transform.position, onDeathEffect.transform.rotation);
            }
        }
        return condition;
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Enemy")
        {
            StartCoroutine(die(true));
            Instantiate(onDeathEffect, transform.position, onDeathEffect.transform.rotation);
            if (c.gameObject.layer == 9)
            {
                Destroy(c.gameObject);
            }
        }
    }

    void enableScriptsAndComponents(bool value)
    {
        if(!value) Camera.main.GetComponent<CameraController>().cameraTarget = null;
        GetComponentInChildren<Animator>().enabled = value;
        GetComponentInChildren<Interact>().DestroyTexts();
        GetComponent<Collider>().material = GetComponentInChildren<GroundDetector>().noFrictionMat;
        var scripts = gameObject.GetComponents<MonoBehaviour>().ToList();
        var scriptsChildren = gameObject.GetComponentsInChildren<MonoBehaviour>().ToList();
        scripts.AddRange(scriptsChildren);
        foreach (var script in scripts)
        {
            script.enabled = value;
        }
    }

    void addDeathPhysics()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
        rb.drag = 1;
        rb.AddForce(transform.right * -deathKnockbackForce);
    }
}
