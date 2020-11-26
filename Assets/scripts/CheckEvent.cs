using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEvent : MonoBehaviour
{
    public float spawnDistance;
    public float despawnDistance;
    public Vector2[] eventLocations;
    public float d;

    void Update()
    {
        Vector2 currentPos = new Vector2(GPS.Instance.latitude, GPS.Instance.longitude);
        //Vector2 currentPos = new Vector2(52, 600);
        for(int i = 0; i < eventLocations.Length; i++)
        {
            float dist = Vector2.Distance(currentPos, eventLocations[i]);
            GPS.Instance.message3 = dist.ToString();
            Debug.Log(dist);
            if (dist <= spawnDistance)
            {
                CustomEvent.Instance.CreateEvent(i);
                GPS.Instance.message = "creating event ";
                Debug.Log("creating event");
            }
            else if (dist >= despawnDistance)
            {
                CustomEvent.Instance.DeleteEvent(i);
                GPS.Instance.message3 = dist.ToString();
                GPS.Instance.message = "deleting event ";
                Debug.Log("deleting event");
            }
            else
            {
                GPS.Instance.message = "doing nothing ";
                Debug.Log("doing nothing");
            }
        }
    }
}
