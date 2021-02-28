using UnityEngine;
using DG.Tweening;

public class LaserTrap : TriggerEvent
{
    public float bulletVelocity;

    [Header("Dependencies")]
    public Transform firePoint;
    public GameObject bullet;
    

    public override void OnTriggerEvent(GameObject triggerer, GameObject triggeredObject)
    {
        GameObject _bullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        _bullet.transform.GetComponent<Rigidbody>().velocity = _bullet.transform.right * bulletVelocity;
        triggeredObject.transform.DOLocalMoveY(-0.05f, 0.1f).OnComplete(()=> {
            if(triggeredObject.GetComponent<Trigger>().triggerTimes > 0)
            {
                triggeredObject.transform.DOLocalMoveY(0, 0.1f);
            }
        });
        AudioManager.Instance.play("Trigger Trap");
    }


}
