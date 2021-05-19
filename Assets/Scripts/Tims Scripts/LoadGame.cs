using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    private GameObject[] LoadObjs;
    public GameManager gm;
    public bool searchforgamemaster=false;

    private void Awake()
    {
        if (LoadObjs != null && LoadObjs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Update()
    {
        if (searchforgamemaster==true)
        {
            gm = FindObjectOfType<GameManager>();
            LoadOnEventOfYourChoice();
        }
    }

    public void LoadOnEventOfYourChoice()
    {
        SaveGameData data = SaveGameSystem.LoadData();

        if (gm == null)
        {
            SceneManager.LoadScene(data.level);
            searchforgamemaster = true;
        }
        else
        {
            gm.coins = data.coins;
            gm.hp = data.health;
            gm.healthpotions = data.healthpotions;
            gm.maxHealthpotions = data.maxHealthpotions;
            Destroy(this.gameObject);
        }
    }

}
