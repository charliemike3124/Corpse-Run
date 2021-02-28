using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : Enemy {
    [Header ("Land enemy characteristic")]
    [SerializeField] private float _triggerDistanceFromPlayer;
    private Vector3 noRot = new Vector3 (0, 0, 0);
    private Vector3 yesRot = new Vector3 (0, 180, 0);
    // Start is called before the first frame update
    void Start () {
        _currentTargetPos = _startPos;
        _parentTransform = this.transform.parent.transform;
    }

    // Update is called once per frame
    void Update () {
        if (CheckDistance ()) {
            if (this.transform.position.x - _targetPlayer.transform.position.x < 0) {
                _parentTransform.eulerAngles = yesRot;
            } else {
                _parentTransform.eulerAngles = noRot;
            }
            if (_canAttack)
                StartCoroutine (Attack ());
        } else {
            Move ();
            CheckRotation ();
        }
    }
    private bool CheckDistance () {
        return Vector3.Distance (this.transform.position, _targetPlayer.transform.position) < _triggerDistanceFromPlayer;
    }

    private void CheckRotation () {
        if (_currentTargetPos == _startPos) {
            _parentTransform.eulerAngles = noRot;
        } else {
            _parentTransform.eulerAngles = yesRot;
        }
    }
}