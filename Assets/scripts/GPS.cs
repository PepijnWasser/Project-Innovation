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
    public string message;

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

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            message = "User has not enabled GPS";
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
            message = "Timed out";
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            message = "Unable to determine device location";
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        yield break;
    }
}
