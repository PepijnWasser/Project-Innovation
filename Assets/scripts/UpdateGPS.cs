using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPS : MonoBehaviour
{
    public Text coords;

    private void Update()
    {
        if (coords == null)
        {
            Debug.Log("if statement");
        }
        if (GPS.Instance == null)
        {
            Debug.Log("gps null");
        }
            coords.text = "Lat: " + GPS.Instance.latitude.ToString() + "\nLon: " + GPS.Instance.longitude.ToString() + "\n" + GPS.Instance.message;
        
    }

}
