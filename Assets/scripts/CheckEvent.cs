using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEvent : MonoBehaviour
{
    public float spawnDistance;
    public float despawnDistance;
    public Vector2[] eventLocations;

    public static CheckEvent Instance { set; get; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        Vector2 currentPos = new Vector2(GPS.Instance.latitude, GPS.Instance.longitude);

        for(int i = 0; i < eventLocations.Length; i++)
        {
            float dist = Vector2.Distance(currentPos, eventLocations[i]);
            GPS.Instance.distance = dist.ToString();
            Debug.Log(dist);
            if (dist <= spawnDistance)
            {
                CustomEvent.Instance.CreateEvent(i);
                GPS.Instance.status = "creating event ";
                Debug.Log("creating event");
            }
            else if (dist > despawnDistance)
            {
                CustomEvent.Instance.DeleteEvent(i);
                GPS.Instance.distance = dist.ToString();
                GPS.Instance.status = "deleting event ";
                Debug.Log("deleting event");
            }
            else
            {
                GPS.Instance.status = "doing nothing ";
                Debug.Log("doing nothing");
            }
        }
    }
}
