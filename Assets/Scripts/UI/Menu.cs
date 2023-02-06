using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject MenuImage;

    private void Start()
    {
        PlayerStats.Dead += TextUpdate;
        BOSS.Die += TextUpdate;
        MenuImage.SetActive(false);
    }

    void TextUpdate(string txt)
    {
        MenuImage.SetActive(true);
        text.text = txt;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        PlayerStats.Dead -= TextUpdate;
        BOSS.Die -= TextUpdate;
    }
}
