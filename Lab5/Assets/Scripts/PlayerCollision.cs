using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAudioController audioController;
    [SerializeField] private float waitTime = 0.03f;

    private Collider2D _playerCollider;
    private void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
    }
    private IEnumerator waitDamage()
    {
        audioController.PlayDeathSound();
        yield return new WaitForSeconds(waitTime);
        playerController.TakeDamage();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out JumpPad jumpPad))
        {
            playerController.Jump(jumpPad.GetJumpPadForce(), jumpPad.GetAdditionalSleepJumpTime());
            jumpPad.TriggerJumpPad();
        }
        else if (col.TryGetComponent(out Collectibles collectible))
        {
            var collectibleType = collectible.GetCollectibleInfoOnContact();

            switch (collectibleType)
            {
                case CollectibleType.DoubleJump:
                    playerController.EnableDoubleJump();
                    break;
                case CollectibleType.RefillHealth:
                case CollectibleType.RefillEnergy:
                case CollectibleType.RefillDash:
                default:
                    break;
            }
            
            Debug.Log(collectibleType);
        }

        if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            audioController.PlayDeathSound();
            StartCoroutine(waitDamage());
        }
        

        #region Unused

        /*if (!col.TryGetComponent(out Collectibles collectible)) return;  
        // This is an inverted if. If the above condition is not met, return void (stop this function).
        
        var collectibleType = collectible.GetCollectibleInfoOnContact();

        switch (collectibleType)
            {
                case CollectibleType.Red:
                    spriteRenderer.color = redColor;
                    break;
                case CollectibleType.Green:
                    spriteRenderer.color = greenColor;
                    break;
                case CollectibleType.Blue:
                    spriteRenderer.color = blueColor;
                    break;
            }*/

        #endregion
    }
}
