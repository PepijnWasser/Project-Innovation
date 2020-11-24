﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPS : MonoBehaviour
{
    public Text coords;

    private void Update()
    {
        coords.text =
            "Lat: " + GPS.Instance.latitude.ToString() +
            "\nLon: " + GPS.Instance.longitude.ToString() +
            "\n" + GPS.Instance.message +
            "\n" + GPS.Instance.message3 +
            "\n" + GPS.Instance.message2 +
            "\n" + GPS.Instance.message4;
    }
}
