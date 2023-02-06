using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void Start()
    {
        //Crystal.Die1 += Die;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
