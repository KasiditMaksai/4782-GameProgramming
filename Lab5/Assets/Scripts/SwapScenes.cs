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
        }
    }

