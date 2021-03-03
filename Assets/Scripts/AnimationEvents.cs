using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [Header("Dependencies")]
    public GroundDetector GD;
    public Transform walkingSpawningPoint;

    public void PlaySound(string soundName)
    {
        if (GD.isGrounded)
        {
            AudioManager.Instance.play(soundName);
        }
    }

    public void SpawnWalkingEffect(GameObject effect)
    {
        if (GD.isGrounded)
        {
            Instantiate(effect, walkingSpawningPoint.position, transform.rotation);
            AudioManager.Instance.play("Step");
        }
    }
}
