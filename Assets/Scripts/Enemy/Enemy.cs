using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    [Header ("Components")]
    [SerializeField] private Transform _weaponPos;
    [SerializeField] protected Transform _startPos;
    [SerializeField] protected Transform _endPos;
    protected bool _canMove = true;
    protected bool _canAttack = true;
    protected Transform _currentTargetPos;
    protected Transform _parentTransform;

    [Space (5)]

    [Header ("Stats")]
    [SerializeField] private float _bulletVel = 3.0f;
    [SerializeField] private float _health = 1.0f;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] protected float _moveVelocity = 10.0f;
    [SerializeField] protected float _damage = 1.0f;

    [Space (5)]

    [Header ("Dependencies")]
    [SerializeField] protected Transform _targetPlayer;
    [SerializeField] protected GameObject _bullet;

    public abstract void Move(); 

    protected IEnumerator Attack () {
        _canAttack = false; 
        GameObject m_bullet = Instantiate (_bullet, _weaponPos.position, _weaponPos.rotation);
        m_bullet.transform.GetComponent<Rigidbody> ().velocity = m_bullet.transform.right * _bulletVel;
        yield return new WaitForSeconds(_fireRate); 
        _canAttack = true; 
    }

}