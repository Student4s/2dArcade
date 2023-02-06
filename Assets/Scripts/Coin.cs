using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]private int score = 1;
    public delegate void AddScore(int scor);

    public static event AddScore AddScore1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AddScore1(score);
            gameObject.SetActive(false);
        }
            
    }
}
