using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public float maxVelocityX;
    private float regularSpeed;
    public float runSpeed;
    public GameObject runLinesEffect;

    [Header("Jump")]
    public float jumpForce;

    [Header("Dependencies")]
    public Transform mesh;

    private InputManager IM;
    private Rigidbody RB;
    private GroundDetector GD;
    private Animator anim;
    public List<Tween> tweens = new List<Tween>();

    void Start()
    {
        IM = GetComponent<InputManager>();
        RB = GetComponent<Rigidbody>();
        GD = GetComponentInChildren<GroundDetector>();
        anim = GetComponentInChildren<Animator>();
        regularSpeed = maxVelocityX;
    }

    void Update()
    {
        if (IM.jump) jump();
        run();

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
            RB.velocity = new Vector3(0, RB.velocity.y, 0);
            tweens.Add(mesh.DORotate(new Vector3(0, mesh.eulerAngles.y, 0), 0.2f));
        }
    }

    void movement(float speed)
    {
        RB.AddForce(transform.right * speed * Time.deltaTime, ForceMode.VelocityChange);        
        anim.SetBool("Walking", true);
        if(speed > 0)
        {
            tweens.Add(mesh.DORotate(new Vector3(0, 0, 10), 0.2f));
        }
        else
        {
            tweens.Add(mesh.DORotate(new Vector3(0, 180, 10), 0.2f));
        }
    
    }

    void jump()
    {
        if (GD.isGrounded)
        {
            RB.AddForce(transform.up * jumpForce, ForceMode.Impulse );
        }
    }

    void run()
    {
        if (IM.run)
        {
            anim.SetFloat("WalkingMulti", 1.25f);
            maxVelocityX = runSpeed;
            runLinesEffect.SetActive(true);
        }
        if(IM.runKeyUp)
        {
            anim.SetFloat("WalkingMulti", 1f);
            maxVelocityX = regularSpeed;
            SWGUtilities.Instance.ExecuteAfterTime(() => {
                runLinesEffect.SetActive(false);
                }, 1.4f);
        }
    }
}
