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

    
    // Show Score
    //[SerializeField] private Text scoreText;
    //[SerializeField] private int playerScore = 10;
    
    // Complete Level Or Not
    [SerializeField]private Slingshot slingshot;
    public List<GameObject> complateBird;
    [SerializeField] private int numberbirds;
    private GameObject activeBird;


    private CoinsManager _coinsManager;
    
    void Start()
    {
        scoreMain = PlayerPrefs.GetInt("_mainScore");
        //scoreText.text = playerScore.ToString();
        _coinsManager = FindObjectOfType<CoinsManager>();
    }

    private void Update()
    {
        NextImageBirds();
        WinLevel();
    }

    /*
    public void AddToScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }*/
    
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
                PlayerPrefs.SetInt("levelReached",LevelToUnlock);
                if (PlayerPrefs.HasKey("_mainScore"))
                    PlayerPrefs.SetInt("_mainScore", scoreMain + _coinsManager.Coins);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.Log("Try Again!");
            }
        }
    }
    
    
}
