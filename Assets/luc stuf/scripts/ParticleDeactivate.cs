using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ParticleDeactivate : MonoBehaviour
{
    public ParticleSystem particleFire;
    public ParticleSystem particleSmoke;
    public int particleAmount = 1;
    public AudioSource source;
    void Start()
    {
        source.Play();

    }
    void FixedUpdate()
    {
        particleFire.Emit(particleAmount);
        particleSmoke.Emit(particleAmount);
    }
    void OnMouseDown()
    {
        source.Stop();
        AudioSource FireOff;
        particleAmount = 0;
        FireOff = GetComponent<AudioSource>();
        FireOff.Play(0);
        
    }
}

