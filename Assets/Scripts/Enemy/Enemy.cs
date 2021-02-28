using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] protected Transform _startPos; 
    [SerializeField] protected Transform _endPos; 
    [SerializeField] protected Transform _weaponPos; 
    protected bool _canMove = true; 
    protected bool _canAttack = true; 
    protected Transform _currentTargetPos; 
    protected Transform _parentTransform; 

    [Space(5)]

    [Header("Characteristics")]
    [SerializeField] protected float _velocity = 10.0f;
    [SerializeField] protected float _damage = 1.0f; 
    [SerializeField] protected float _fireRate = 0.5f; 
    [SerializeField] protected float _health = 1.0f; 
    [SerializeField] protected Vector3 _bulletDir; 
    [SerializeField] protected float _bulletVel = 3.0f; 

    [Space(5)]

    [Header("Target")]
    [SerializeField] protected Transform _target;  

    [Space(5)]

    [Header("Target")]
    [SerializeField] protected GameObject _bullet; 
    public abstract void Move();
    public abstract void Attack(); 
    public abstract IEnumerator AttackCounter(); 
}
