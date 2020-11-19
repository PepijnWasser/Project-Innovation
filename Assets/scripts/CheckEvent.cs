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
        for(int i = 0; i < eventLocations.Length; i++)
        {
            float dist = Vector2.Distance(currentPos, eventLocations[i]);
            //GPS.Instance.message = dist.ToString();
            if (dist <= spawnDistance)
            {
                CustomEvent.Instance.CreateEvent(i);
                GPS.Instance.message = "creating event " + dist;
            }
            else if (dist >= despawnDistance)
            {
                CustomEvent.Instance.DeleteEvent(i);
                GPS.Instance.message = "deleting event " + dist;
            }
            else
            {
                GPS.Instance.message = "doing nothing " + dist;
            }
        }
    }
}
