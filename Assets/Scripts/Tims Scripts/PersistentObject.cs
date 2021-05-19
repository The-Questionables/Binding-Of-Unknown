using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour {
    public List<string> avoidScenes = new List<string>();
    private GameObject[] perObjs;

    // Use this for initialization
    void Awake () {
        perObjs = GameObject.FindGameObjectsWithTag("Persistent");

        if (perObjs != null && perObjs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

	}


    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.Scene arg1)
    {
        if (perObjs != null && avoidScenes.Contains(arg1.name))
        {
            for (int i = 0; i < perObjs.Length; i++)
            {
                Destroy(perObjs[i]); 
            }
        }
    }
}
