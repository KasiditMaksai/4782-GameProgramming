using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips winAudioClips;
    [SerializeField] private SoAudioClips deathAudioClips;
    [SerializeField] private SoAudioClips fallAudioClips;
    [SerializeField] private SoAudioClips jumppadAudioClips;
    [SerializeField] private SoAudioClips pickAudioClips;
    [SerializeField] private SoAudioClips respawnAudioClips;
    
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClips.GetAudioClip());
    }

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip(), 0.5f);
    }

    /*public void PlayWinSound()
    {
        audioSource.PlayOneShot(winAudioClips.GetAudioClip());
    }*/

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathAudioClips.GetAudioClip());
    }
    
    public void PlayFallSound()
    {
        audioSource.PlayOneShot(fallAudioClips.GetAudioClip());
    }

    public void PlayJumppadSound()
    {
        audioSource.PlayOneShot(jumppadAudioClips.GetAudioClip());
    }
    
    public void PlayPickSound()
    {
        audioSource.PlayOneShot(pickAudioClips.GetAudioClip());
    }
    
    public void PlayRespawnSound()
    {
        audioSource.PlayOneShot(respawnAudioClips.GetAudioClip());
    }
}
