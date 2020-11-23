using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCollision : MonoBehaviour
{
    public Vector3 MoveCar;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnMouseDown()
    {
        //gameObject.transform.position = transform.position + MoveCar;
        //animator.SetTrigger("MoveCar");
        animator.SetBool("MoveBool",true);

    }
}
