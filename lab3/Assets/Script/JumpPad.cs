using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController player;
    [SerializeField] private float jumpPadForce = 13f;
    [SerializeField] private float additionalSleepJumpTime = 0.3f;

    private static readonly int Bounce = Animator.StringToHash("Bounce");

    public float GetJumpPadForce() => jumpPadForce;
    public float GetAdditionalSleepJumpTime() => additionalSleepJumpTime;

    public void TriggerJumpPad()
    {
        animator.SetTrigger("Bounce");
        player.Jump(jumpPadForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TriggerJumpPad();
        }
    }
}
