using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
   [SerializeField] private Image HP;
   [SerializeField] private Text Score;
   private int totalScore=0;
    void Start()
    {
        PlayerStats.ChangeScore1+= ScoreChange;
        PlayerStats.ChangeHP1 += HPChange;
        Melee.AddScore1 += ScoreChange;
        Range.AddScore1 += ScoreChange;
        Coin.AddScore1+= ScoreChange;
        BOSS.AddScore1+=ScoreChange;
    }

    void HPChange(float hp, float maxHP)
    {
        float fill = hp / maxHP;
        HP.fillAmount = fill;
    }

    void ScoreChange(int score)
    {
        totalScore += score;
        Score.text = ""+totalScore;
    }

    private void OnDestroy()
    {
        PlayerStats.ChangeScore1-= ScoreChange;
        PlayerStats.ChangeHP1 -= HPChange;
        Melee.AddScore1 -= ScoreChange;
        Range.AddScore1 -= ScoreChange;
        Coin.AddScore1-= ScoreChange;
        BOSS.AddScore1-=ScoreChange;
    }
}
