using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cup : MonoBehaviour
{
    private GameManger gameManger;
    
    private void Awake()
    {
        gameManger = FindObjectOfType<GameManger>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Bird"))
        {
            Bird bird = other.gameObject.GetComponent<Bird>();
            gameManger.AddToScore(bird.ScoreCoin);
            gameManger.complateBird.Add(bird.gameObject);
            bird.gameObject.SetActive(false);
        }
    }
}
