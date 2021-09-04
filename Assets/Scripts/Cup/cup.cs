using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cup : MonoBehaviour
{
    private Game game;
    [SerializeField]private Slingshot slingshot;
    [SerializeField] private List<GameObject> complateBird;
    [SerializeField] private int numberbirds;
    private GameObject activeBird;
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

    private void Update()
    {
        activeBird = GameObject.FindGameObjectWithTag("Bird");
        if (slingshot.birdPrefab.Count == 0 && !activeBird)
        {
            if (complateBird.Count == numberbirds)
            {
                Debug.Log("Complate Level");
            }
            else
            {
                Debug.Log("Try Again!");
            }
        }
    }
}
