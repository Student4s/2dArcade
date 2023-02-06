using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Hitable
{
    private int score;
    private float maxHP = 10f;
    
    public delegate void ChangeScore(int scor);

    public static event ChangeScore ChangeScore1;
    
    public delegate void ChangeHP(float hp, float maxHP);

    public static event ChangeHP ChangeHP1;
    
    public delegate void PlayerDeath(string a);

    public static event PlayerDeath Dead;
    private void Start()
    {
        Melee.AddScore1 += AddScore;
        
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        ChangeHP1(hp,maxHP);
    }

    public void AddScore(int scor)
    {
        score += scor;
        ChangeScore1(score);
    }

    protected override void Death()
    {
        Dead("Вы умерли");
        Time.timeScale = 0f;
    }
}
