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
    ParticleSystem Clicked;
    void Start()
    {
        source.Play();
        Clicked = this.transform.Find("Clicked!").GetComponent<ParticleSystem>();
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
        Clicked.Play();

    }
}

