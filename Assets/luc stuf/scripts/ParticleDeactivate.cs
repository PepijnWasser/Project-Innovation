using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ParticleDeactivate : MonoBehaviour
{
    ParticleSystem particleFire;
    ParticleSystem particleSmoke;
    public AudioSource source;
    ParticleSystem Clicked;
    void Start()
    {
        source.Play();
        Clicked = this.transform.Find("Clicked!").GetComponent<ParticleSystem>();
        particleFire = this.transform.Find("Fire").GetComponent<ParticleSystem>();
        particleSmoke = this.transform.Find("Smoke").GetComponent<ParticleSystem>();
        particleFire.Play();
        particleSmoke.Play();
    }
    void OnMouseDown()
    {
        source.Stop();
        AudioSource FireOff;
        particleFire.Stop();
        particleSmoke.Stop();
        FireOff = GetComponent<AudioSource>();
        FireOff.Play(0);
        Clicked.Play();
    }
}

