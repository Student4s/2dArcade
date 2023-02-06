using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInCell : MonoBehaviour
{
    public Image itemIcon;
    public Text txtcount;
    public int count;
    
    public RectTransform rect;

    public CanvasGroup canvasGroup;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
}
