using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private int playerScore = 10;
    
    void Start()
    {
        scoreText.text = playerScore.ToString();
    }
    
    public void AddToScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }
    
    
    
}
