using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class Land : Enemy {
    [Header ("characteristic")]
    [SerializeField] private float _triggerDistanceFromPlayer;
    [SerializeField] private float _rotationAnimSmoothness = 0.5f; 
    private Vector3 noRot = new Vector3 (0, 0, 0);
    private Vector3 yesRot = new Vector3 (0, 180, 0);
    // Start is called before the first frame update
    void Start () {
        DOTween.Init(); 
        _currentTargetPos = _startPos;
        _parentTransform = this.transform.parent.transform;
    }

    // Update is called once per frame
    void Update () {
        if (CheckDistance ()) {
            if (this.transform.position.x - _targetPlayer.transform.position.x < 0) {
                _parentTransform.transform.DORotate(yesRot, _rotationAnimSmoothness); 
            } else {
                _parentTransform.transform.DORotate(noRot, _rotationAnimSmoothness); 
            }
            if (_canAttack)
                StartCoroutine (Attack ());
        } else {
            Move ();
            CheckRotation ();
        }
    }

    public override void Move () {
        float delta = _moveVelocity * Time.deltaTime;
        _parentTransform.position = Vector3.MoveTowards (_parentTransform.position, _currentTargetPos.position, delta);
        if (Vector3.Distance (_parentTransform.position, _currentTargetPos.position) < 0.001f) {
            //change target
            if (_currentTargetPos == _startPos) {
                _currentTargetPos = _endPos;
                return;
            }

            _currentTargetPos = _startPos;
        }
    }
    private bool CheckDistance () {
        return Vector3.Distance (this.transform.position, _targetPlayer.transform.position) < _triggerDistanceFromPlayer;
    }

    private void CheckRotation () {
        if (_currentTargetPos == _startPos) {
            _parentTransform.transform.DORotate(noRot, _rotationAnimSmoothness); 
            //_parentTransform.eulerAngles = noRot;
        } else {
            _parentTransform.transform.DORotate(yesRot, _rotationAnimSmoothness); 
            //_parentTransform.eulerAngles = yesRot;
        }
    }
}