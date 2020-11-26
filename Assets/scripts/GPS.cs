using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;
    public string status;
    public string distance;
    public string debugmessage = "tete";

    private bool CoroutineRunning = false;

    private void Start()
    {

#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
        {
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
#endif

        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private void Update()
    {
        if (!CoroutineRunning)
        {
            StartCoroutine(StartLocationService());
        }     
    }

    private IEnumerator StartLocationService()
    {
        CoroutineRunning = true;
        if (!Input.location.isEnabledByUser)
        {
            status = "User has not enabled GPS";
            CoroutineRunning = false;
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait <= 0)
        {
            status = "Timed out";
            CoroutineRunning = false;
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            status = "Unable to determine device location";
            CoroutineRunning = false;
            yield break;
        }

        status = "connected";
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        CoroutineRunning = false;
        yield break;
    }
}
