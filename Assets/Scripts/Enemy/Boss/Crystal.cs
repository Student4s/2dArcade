using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crystal : Hitable
{
    public UnityAction CrystalDestroy;
    
    protected override void Death()
    {
        CrystalDestroy?.Invoke();
        Destroy(gameObject);
    }
}
