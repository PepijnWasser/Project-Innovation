using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingWall : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnMouseDown()
    {
        animator.SetBool("Explode", true);

    }
}
