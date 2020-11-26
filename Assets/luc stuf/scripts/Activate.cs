using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnMouseDown()
    {
        //animator.SetTrigger("MoveCar");
        animator.SetBool("Activate", true);

    }
}
