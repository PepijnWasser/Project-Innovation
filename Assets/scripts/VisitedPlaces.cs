using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitedPlaces : MonoBehaviour
{
    public static VisitedPlaces Instance { set; get; }
    List<int> placesVisited = new List<int>();

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void addPlace(int sceneNnumber)
    {
        if (!placesVisited.Contains(sceneNnumber))
        {
            placesVisited.Add(sceneNnumber);
            if(placesVisited.Count >= CheckEvent.Instance.eventLocations.Length)
            {
                GPS.Instance.debugmessage = "you won gg ez clap";
            }
        }
    }
}
