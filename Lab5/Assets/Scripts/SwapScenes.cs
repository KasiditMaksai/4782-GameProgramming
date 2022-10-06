using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    void Update()
        {
            if (SceneManager.GetActiveScene().name == "Main menu")
                BGSound.instance.GetComponent<AudioSource>().Pause();
            if (SceneManager.GetActiveScene().name == "Level 1")
                BGSound.instance.GetComponent<AudioSource>().UnPause();
        }
    }

