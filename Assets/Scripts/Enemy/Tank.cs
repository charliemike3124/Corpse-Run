using UnityEngine;
using DG.Tweening; 

public class Tank : Enemy {
    [Header ("characteristic")]
    [SerializeField] private float _triggerDistanceFromPlayer;
    private Vector3 noRot = new Vector3 (0, 0, 0);
    private Vector3 yesRot = new Vector3 (0, 180, 0);
    
    [Header("Animation Parameters")]
    [SerializeField] private float _rotationAnimSmoothness = 0.5f; 
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
                _parentTransform.transform.DORotate(yesRot, _rotationAnimSmoothness).SetAutoKill(); 
            } else {
                _parentTransform.transform.DORotate(noRot, _rotationAnimSmoothness).SetAutoKill(); 
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
        if(_targetPlayer != null)
            return Vector3.Distance (this.transform.position, _targetPlayer.transform.position) < _triggerDistanceFromPlayer;
        return false; 
    }

    private void CheckRotation () {
        if (_currentTargetPos == _startPos) {
            _parentTransform.transform.DORotate(noRot, _rotationAnimSmoothness).SetAutoKill(); 
        } else {
            _parentTransform.transform.DORotate(yesRot, _rotationAnimSmoothness).SetAutoKill(); 
        }
    }
}