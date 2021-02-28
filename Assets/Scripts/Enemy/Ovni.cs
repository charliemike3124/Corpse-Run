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
            StartCoroutine(Attack()); 
    }

    public override void Move(){
        float delta = _moveVelocity * Time.deltaTime; 
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

}
