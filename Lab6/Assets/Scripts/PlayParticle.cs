using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    private void OnEnable()
    {
        particle.Play();
    }
}
