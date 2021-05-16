using DG.Tweening;
using UnityEngine;

public class TweenRotate : MonoBehaviour
{
    
    public float loopTime;
    public LoopType loopType;
    public float[] rot = new float[3];
    public bool[] rotationAxis = new bool[3];
    public Ease tweenEase;
     
    void Start()
    {
        rot[0] = rotationAxis[0] ? rot[0]: transform.rotation.eulerAngles.x;
        rot[1] = rotationAxis[1] ? rot[1]: transform.rotation.eulerAngles.y;
        rot[2] = rotationAxis[2] ? rot[2]: transform.rotation.eulerAngles.z;

        Vector3 rotation = new Vector3(rot[0], rot[1], rot[2]);

        transform.DOLocalRotate(rotation, loopTime, RotateMode.FastBeyond360)
            .SetEase(tweenEase)
            .SetLoops(-1, loopType)
            .SetAutoKill(true);
    } 
}
