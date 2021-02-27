using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [Header("Dependencies")]
    public GroundDetector GD;

    public void PlaySound(string soundName)
    {
        if (GD.isGrounded)
        {
            AudioManager.Instance.play(soundName);
        }
    }
}
