using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    
    public float hp;

    virtual public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }

    virtual protected void Death()
    {
        gameObject.SetActive(false);
    }
}