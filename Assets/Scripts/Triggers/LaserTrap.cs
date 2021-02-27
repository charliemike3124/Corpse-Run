using UnityEngine;

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
    }


}
