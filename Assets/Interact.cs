using DG.Tweening;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float dropForce;
    public int holdLayer;
    private int originalLayer;
    private GameObject interactableObject;

    [Header("Dependencies")]
    public Transform grabPoint;
    public GameObject PE_Interact_Text;
    public GameObject PE_Toggle_Text;

    private PlayerManager player;
    private Animator anim;
    private bool isHoldingObject;
    private GameObject holdedObject;
    private GameObject interactText;
    private GameObject toggleText;

    void Start()
    {
        player = GetComponentInParent<PlayerManager>();
        anim = player.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (isHoldingObject)
        {
            if (!GameManager.Instance.toggle)
            {
                GameManager.Instance.toggle = true;
                toggleText = Instantiate(PE_Toggle_Text, player.transform.position + Vector3.up*1.5f, PE_Interact_Text.transform.rotation);
                toggleText.transform.parent = player.transform;

            }
            if (player.GetComponent<InputManager>().interact)
            {
                anim.SetBool("HoldingUp", false);
                anim.SetBool("HoldingFront", false);
                isHoldingObject = false;
                holdedObject.transform.SetParent(null);
                holdedObject.GetComponent<Rigidbody>().isKinematic = false;
                holdedObject.GetComponent<Rigidbody>().AddForce(holdedObject.transform.right * -dropForce);
                holdedObject.GetComponent<PlayerManager>().isBeingHeld = false;
                holdedObject.layer = originalLayer;
            }
            if (player.GetComponent<InputManager>().toggleHold)
            {
                if (anim.GetBool("HoldingUp"))
                {
                    anim.SetBool("HoldingUp", false);
                    anim.SetBool("HoldingFront", true);
                }
                else
                {
                    anim.SetBool("HoldingUp", true);
                    anim.SetBool("HoldingFront", false);
                }
                if (toggleText != null)
                {
                    Destroy(toggleText);
                }
            }
        }

        if (player.GetComponent<InputManager>().interact && holdedObject == null && interactableObject != null)
        {
            Destroy(interactText);
            GameManager.Instance.interaction = true;
            holdedObject = interactableObject.gameObject;
            holdedObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f);
            holdedObject.transform.position = grabPoint.position;
            originalLayer = holdedObject.layer;
            holdedObject.gameObject.layer = holdLayer;
            holdedObject.GetComponent<Rigidbody>().isKinematic = true;
            holdedObject.GetComponent<PlayerManager>().isBeingHeld = true;
            holdedObject.transform.SetParent(grabPoint);
            isHoldingObject = true;
            anim.SetBool("HoldingUp", true);
        }

        if (!isHoldingObject)
        {
            holdedObject = null;
        }
    }
 
    void OnTriggerEnter(Collider c)
    {
        var beingHeld = c.GetComponent<PlayerManager>()?.isBeingHeld ?? false;
        if (c.tag == player.INTERACTABLE_TAG && !beingHeld)
        {
            interactableObject = c.gameObject;
            if(!GameManager.Instance.interaction)
            {
                interactText = Instantiate(PE_Interact_Text, c.transform.position + Vector3.up, PE_Interact_Text.transform.rotation);
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == player.INTERACTABLE_TAG)
        {
            interactableObject = null;
            Destroy(interactText);
        }
    }

    public void DestroyTexts()
    {
        if(interactText) Destroy(interactText);
        if(toggleText) Destroy(toggleText);
    }
}
