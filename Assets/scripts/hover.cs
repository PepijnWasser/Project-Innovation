using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
    Vector3 startPos;
    float rot;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rot += 20 * Time.deltaTime;
        transform.position = new Vector3(0, Mathf.Sin(Time.time) * 0.25f, 0);
        transform.rotation = Quaternion.Euler(0, rot, 0);
    }
}
