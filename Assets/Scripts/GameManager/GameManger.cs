using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Cinemachine;

public class GameManger : MonoBehaviour
{
    int scoreMain;


    [SerializeField] private int LevelToUnlock;
    
    // use for image birds
    private GameObject _blueBird;
    private GameObject _yellowBird;
    [SerializeField] private List<GameObject> imageBirds;


    
    // Complete Level Or Not
    [SerializeField]private Slingshot slingshot;
    public List<GameObject> complateBird;
    [SerializeField] private int numberbirds;
    private GameObject activeBird;


    private CoinsManager _coinsManager;
    
    void Start()
    {
        scoreMain = PlayerPrefs.GetInt("_mainScore");
        _coinsManager = FindObjectOfType<CoinsManager>();
    }

    private void Update()
    {
        NextImageBirds();
        WinLevel();
    }

    
    void NextImageBirds()
    {
        _blueBird = GameObject.Find("BlueBird(Clone)");
        _yellowBird = GameObject.Find("YellowBird(Clone)");

        if (_blueBird)
        {
            Destroy(imageBirds[0]);
            return;
        }
        else if (_yellowBird)
        {
            Destroy(imageBirds[1]);
            return;
        }

    }

    void WinLevel()
    {
        activeBird = GameObject.FindGameObjectWithTag("Bird");
        if (slingshot.birdPrefab.Count == 0 && !activeBird)
        {
            if (complateBird.Count == numberbirds)
            {
                Debug.Log("Complate Level");
                AudioMaster.Play(8);
                PlayerPrefs.SetInt("levelReached",LevelToUnlock);
                PlayerPrefs.SetInt("_mainScore", scoreMain + _coinsManager.Coins);
                Debug.Log("Save" + _coinsManager.Coins);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.Log("Try Again!");
            }
        }
    }
    
    
}
