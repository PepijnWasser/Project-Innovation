using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPS : MonoBehaviour
{
    public Text coords;

    private void Update()
    {
        coords.text =
            "\nStatus: " + GPS.Instance.status +
            "\nLat: " + GPS.Instance.latitude.ToString() +
            "\nLon: " + GPS.Instance.longitude.ToString() +
            "\nDist: " + GPS.Instance.distance +
            "\n" + GPS.Instance.debugmessage;
    }
}
