using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public float maxVelocityX;

    [Header("Jump")]
    public float jumpForce;

    [Header("Dash")]
    public float dashForce;
    public float dashCooldown;
    private Coroutine dashCoroutine;
    private bool dashOnCooldown;

    [Header("Dependencies")]
    public Transform mesh;

    private InputManager IM;
    private Rigidbody RB;
    private GroundDetector GD;
    private Animator anim;

    void Start()
    {
        IM = GetComponent<InputManager>();
        RB = GetComponent<Rigidbody>();
        GD = GetComponentInChildren<GroundDetector>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (IM.jump) jump();
        if (IM.dash) dash();

        float velocityX = Mathf.Clamp(RB.velocity.x, -maxVelocityX, maxVelocityX);
        RB.velocity = new Vector2(velocityX, RB.velocity.y);
    }
    void FixedUpdate()
    {
        if (IM.right) movement(movementSpeed);
        else if (IM.left) movement(-movementSpeed);
        else 
        { 
            anim.SetBool("Walking", false);
            mesh.DORotate(new Vector3(0, mesh.eulerAngles.y, 0), 0.2f);
        }
    }

    void movement(float speed)
    {
        RB.AddForce(transform.right * speed * Time.deltaTime);        
        anim.SetBool("Walking", true);
        if(speed > 0)
        {
            mesh.DORotate(new Vector3(0, 0, 10), 0.2f);
        }
        else
        {
            mesh.DORotate(new Vector3(0, 180, 10), 0.2f);
        }
    
    }

    void jump()
    {
        if (GD.isGrounded)
        {
            RB.AddForce(transform.up * jumpForce );
        }
    }

    void dash()
    {
        if (!dashOnCooldown)
        {
            Vector3 direction = new Vector3();
            if (IM.right) direction = Vector3.right;
            else direction = Vector3.left;

            maxVelocityX = maxVelocityX + 3;
            RB.velocity = new Vector3(RB.velocity.x, 0);
            RB.AddForce(direction * dashForce);
            dashCoroutine = StartCoroutine(IDashCD());
        }
    }
    IEnumerator IDashCD()
    {
        dashOnCooldown = true;
        yield return new WaitForSeconds(dashCooldown);
        maxVelocityX = maxVelocityX - 3;
        dashOnCooldown = false;
    }
}
