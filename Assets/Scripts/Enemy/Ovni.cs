using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovni : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        _currentTargetPos = _startPos; 
        _parentTransform = this.transform.parent.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
        if(_canAttack)
            StartCoroutine(AttackCounter()); 
    }

    public override void Move(){
        float delta = _velocity * Time.deltaTime; 
        _parentTransform.position = Vector3.MoveTowards(_parentTransform.position, _currentTargetPos.position, delta); 
        if(Vector3.Distance(_parentTransform.position, _currentTargetPos.position) < 0.001f){
            //change target
            if(_currentTargetPos == _startPos){
                _currentTargetPos = _endPos; 
                return; 
            }

            _currentTargetPos = _startPos; 
        }
    }

    public override void Attack()
    {
        GameObject m_bullet = Instantiate(_bullet, _weaponPos.position, _weaponPos.rotation);
        m_bullet.transform.GetComponent<Rigidbody>().velocity = m_bullet.transform.right * _bulletVel;
    }

    public override IEnumerator AttackCounter()
    {   
        Attack();
        _canAttack = false; 
        yield return new WaitForSeconds(_fireRate); 
        _canAttack = true; 
    }
}
