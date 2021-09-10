﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bird : MonoBehaviour
{

    public int ScoreCoin = 10; // score
    public bool collided;


    public void Release()
    {
        PathPoints.instance.Clear();
        StartCoroutine(CreatePathPoints());
    }

    IEnumerator CreatePathPoints()
    {
        while (true)
        {
            if (collided) break;
            PathPoints.instance.CreateCurrentPathPoint(transform.position);
            yield return new WaitForSeconds(PathPoints.instance.timeInterval);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
        if (collision.gameObject.CompareTag("Ground"))  // check for Destroy object(bird) 
        {
            StartCoroutine(ResetAfterDelay());
        }
    }
    

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        //this.gameObject.SetActive(false);
        if (this.gameObject)
            Destroy(this.gameObject);
        
    }
}
