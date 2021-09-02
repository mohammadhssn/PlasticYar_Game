using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cup : MonoBehaviour
{
    private Game game;
    private void Awake()
    {
        game = FindObjectOfType<Game>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Bird"))
        {
            Bird bird = other.gameObject.GetComponent<Bird>();
            game.AddToScore(bird.ScoreCoin);
            bird.gameObject.SetActive(false);
        }
    }

}
