using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ParticleDeactivate : MonoBehaviour
{
    public ParticleSystem particleFire;
    public ParticleSystem particleSmoke;
    public int particleAmount = 1;
    public int CountDown = 0;
    bool SecondCount = false;
    //public AudioClip source;
    void Start()
    {
        //source = GetComponent<AudioSource>().Play();
        
    }
    void FixedUpdate()
    {
        particleFire.Emit(particleAmount);
        particleSmoke.Emit(particleAmount);
        
        //Debug.Log(CountDown);
    }
    void OnMouseDown()
    {
        AudioSource ThatsWhat;
        particleAmount = 0;
        //AudioSource.PlayClipAtPoint(source, transform.position, 1);
        ThatsWhat = GetComponent<AudioSource>();
        ThatsWhat.Play(0);
    }
    void Update()
    {
        if (SecondCount == false)
        {
            SecondCount = true;
            StartCoroutine(AddSecond());
        }

        IEnumerator AddSecond()
        {
            CountDown += 1;
            yield return new WaitForSeconds(1);
            SecondCount = false;
        }
        if (CountDown > 10)
        {
            CountDown = 0;
            particleAmount = 1;
        }
    }
}

