using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    Animator animator;
    ParticleSystem ClickEff;
    ParticleSystem Clicked;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //ParticleSystem ClickEff = gameObject.GetComponent<ClickableEffect>();
        ClickEff = this.transform.Find("ClickableEffect").GetComponent<ParticleSystem>();
        Clicked = this.transform.Find("Clicked!").GetComponent<ParticleSystem>();
    }
    void OnMouseDown()
    {
        animator.SetBool("Activate", true);
        ClickEff.Stop();
        Clicked.Play();
    }
}
