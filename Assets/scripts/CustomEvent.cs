using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class CustomEvent : MonoBehaviour
{
    public static CustomEvent Instance { set; get; }

    public GameObject[] scenePrefabs;
    public List<GameObject> scenes = new List<GameObject>();
    ARSessionOrigin m_SessionOrigin;

    private void Start()
    {
        Instance = this;
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
        DontDestroyOnLoad(gameObject);
        CreateEvent(0);
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
        if(scenePrefabs.Length >= sceneNumber + 1 )
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
                    //GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    GameObject obj = (GameObject)(Instantiate(scenePrefabs[sceneNumber], Vector3.zero, Quaternion.identity));
                    obj.name = scenePrefabs[sceneNumber].name;
                    obj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    //obj.transform.position = new Vector3(0, -0.5f, 1);
                    m_SessionOrigin.MakeContentAppearAt(obj.transform, new Vector3(0, -0.5f, 1), Quaternion.identity);
                    scenes.Add(obj);
                }
                else
                {
                    Debug.Log("scene already exists");
                }
            }
            else
            {
                Debug.Log("making scene no scene");
                //GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                GameObject obj = (GameObject)(Instantiate(scenePrefabs[sceneNumber], Vector3.zero, Quaternion.identity));
                obj.name = scenePrefabs[sceneNumber].name;
                obj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                m_SessionOrigin.MakeContentAppearAt(obj.transform, new Vector3(0, -0.5f, 1), Quaternion.identity);
                //obj.transform.position = new Vector3(0, -0.5f, 1);
                
                scenes.Add(obj);
            }
        }
        else
        {
            Debug.LogError("Bad input!");
        }
    }
}
