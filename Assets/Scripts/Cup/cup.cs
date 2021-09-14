using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cup : MonoBehaviour
{
    private GameManger gameManger;
    private CoinsManager _coinsManager;
    
    private void Awake()
    {
        gameManger = FindObjectOfType<GameManger>();
        _coinsManager = FindObjectOfType<CoinsManager>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Bird"))
        {
            Bird bird = other.gameObject.GetComponent<Bird>();
            AudioMaster.Play(7);
            _coinsManager.AddCoins(transform.position, bird.ScoreCoin);
            gameManger.complateBird.Add(bird.gameObject);
            bird.gameObject.SetActive(false);
        }
    }
}
