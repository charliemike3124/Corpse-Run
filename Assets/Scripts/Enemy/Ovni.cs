
using DG.Tweening;
using UnityEngine;

public class Ovni : Enemy {
    [Header ("Mesh")]
    [SerializeField] private Transform _meshTransform;

    [Header ("Animation parameters")]
    [SerializeField] private float _velAnim = 0.6f;
    [SerializeField] private float _rotationAnimSmoothness = 0.5f;
    private float _yRot = 0;
    private Vector3 _actualRot = new Vector3 (0, 360, 0);

    void Start () {
        DOTween.Init ();
        _currentTargetPos = _startPos;
        _parentTransform = this.transform.parent.transform;
    }

    void Update () {
        Move ();
        if (_canAttack)
            StartCoroutine (Attack ());
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

}