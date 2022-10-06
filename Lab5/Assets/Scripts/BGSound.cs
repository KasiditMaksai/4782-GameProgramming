using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSound : MonoBehaviour
{
    public static BGSound instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
