using DG.Tweening;
using UnityEngine;

public class TweenLights : MonoBehaviour
{

    public float intensityOffset;
    public float loopDuration;
    public LoopType loopType;
    public Ease tweenEase;

    void Start()
    {
        Light light = transform.GetComponent<Light>();
        light.DOIntensity(light.intensity + intensityOffset, loopDuration)
            .SetEase(tweenEase)
            .SetLoops(-1, loopType)
            .SetAutoKill();        
    }
}
