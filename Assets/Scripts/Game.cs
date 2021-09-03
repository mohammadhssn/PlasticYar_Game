using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private GameObject _blueBird;
    private GameObject _yellowBird;
    [SerializeField] private List<GameObject> imageBirds;



    [SerializeField] private Text scoreText;
    [SerializeField] private int playerScore = 10;
    
    void Start()
    {
        scoreText.text = playerScore.ToString();
    }

    private void Update()
    {
        NextImageBirds();
    }

    public void AddToScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
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
    
    
}
