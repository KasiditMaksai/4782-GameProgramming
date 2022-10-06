using System;
using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour
{
    private const string PlayerTag = "Player";

    private GameManager _gameManager;
    [SerializeField] private float waitTime = 0.1f;
    
    // Why are we checking if the player reaches the finish line here? So, we do not
    // have to check for every time the player collides with something for a finish line.
    
    
    public AudioSource playSound;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(PlayerTag)) return;
        
        StartCoroutine(waitSound());
        playSound.Play();
    }

    private IEnumerator waitSound()
    {
        playSound.Play();
        yield return new WaitForSeconds(waitTime);
        _gameManager.LoadNextLevel();
    }

    

}
