using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CustomEvent : MonoBehaviour
{
    public static CustomEvent Instance { set; get; }

    public GameObject[] scenePrefabs;
    public List<GameObject> scenes = new List<GameObject>();

    ARSessionOrigin m_SessionOrigin;
    ARRaycastManager m_RaycastManager;
    ARSessionOrigin c_m_RaycastManager;

    private void Start()
    {
        m_SessionOrigin = GameObject.FindGameObjectWithTag("origin").GetComponent<ARSessionOrigin>();
        m_RaycastManager = GameObject.FindGameObjectWithTag("origin").GetComponent<ARRaycastManager>();
        Instance = this;
        DontDestroyOnLoad(gameObject);
        c_m_RaycastManager = m_SessionOrigin;
    }

    public void DeleteEvent(int sceneNumber)
    {
        if (scenes.Count > 0)
        {
            List<GameObject> scenesToRemove = new List<GameObject>();

            for (int i = 0; i < scenes.Count; i++)
            {
                if (scenes[i].gameObject.name == scenePrefabs[sceneNumber].name)
                {
                    scenesToRemove.Add(scenes[i]);
                }
            }

            foreach (GameObject scene in scenesToRemove)
            {
                scenes.Remove(scene);
                Destroy(scene.gameObject);
            }

            scenesToRemove.Clear();
        }
    }

    public void CreateEvent(int sceneNumber)
    {
        m_SessionOrigin = c_m_RaycastManager;

        if (scenePrefabs.Length >= sceneNumber + 1 )
        {
            if (scenes.Count > 0)
            {
                bool nameIsThere = false;
                for (int i = 0; i < scenes.Count; i++)
                {
                    string objectname = scenes[i].gameObject.name;
                    string prefabname = scenePrefabs[sceneNumber].name;
                    if (objectname == prefabname)
                    {
                        nameIsThere = true;
                    }
                }
                if (!nameIsThere)
                {
                    Debug.Log("making scnene no name");
                    Vector2 middleScreen = new Vector2(Screen.width / 2, Screen.height / 2);
                    List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

                    if (m_RaycastManager.Raycast(middleScreen, s_Hits, TrackableType.All))
                    {
                        // Raycast hits are sorted by distance, so the first one
                        // will be the closest hit.
                        var hitPose = s_Hits[0].pose;

                        //GameObject obj = (GameObject)(Instantiate(scenePrefabs[sceneNumber], Vector3.zero, Quaternion.identity));
                        GameObject obj = Instantiate(scenePrefabs[sceneNumber], hitPose.position, Quaternion.identity);
                        obj.name = scenePrefabs[sceneNumber].name;

                        // This does not move the content; instead, it moves and orients the ARSessionOrigin
                        // such that the content appears to be at the raycast hit position.
                       // m_SessionOrigin.MakeContentAppearAt(obj.transform, hitPose.position, Quaternion.identity);

                        scenes.Add(obj);
                        VisitedPlaces.Instance.addPlace(sceneNumber);
                    }
                }
                else
                {
                    Debug.Log("scene already exists");
                }
            }
            else
            {
                Debug.Log("making scene no scene" + sceneNumber.ToString());

                Vector2 middleScreen = new Vector2(Screen.width / 2, Screen.height / 2);
                List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

                if (m_RaycastManager.Raycast(middleScreen, s_Hits, TrackableType.All))
                {
                    // Raycast hits are sorted by distance, so the first one
                    // will be the closest hit.
                    var hitPose = s_Hits[0].pose;

                    //GameObject obj = (GameObject)(Instantiate(scenePrefabs[sceneNumber], Vector3.zero, Quaternion.identity));
                    GameObject obj = Instantiate(scenePrefabs[sceneNumber], hitPose.position, Quaternion.identity);
                    obj.name = scenePrefabs[sceneNumber].name;

                    // This does not move the content; instead, it moves and orients the ARSessionOrigin
                    // such that the content appears to be at the raycast hit position.
                    // m_SessionOrigin.MakeContentAppearAt(obj.transform, hitPose.position, Quaternion.identity);

                    scenes.Add(obj);
                    VisitedPlaces.Instance.addPlace(sceneNumber);
                }
            }
        }
        else
        {
            Debug.LogError("Bad input!");
        }
    }
}