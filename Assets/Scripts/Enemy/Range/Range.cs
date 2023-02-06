using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Hitable
{
    [SerializeField] private GameObject hero;
    [SerializeField]private GameObject shootPoint;
    [SerializeField]private GameObject gun;
    [SerializeField]private GameObject bullet;
    [SerializeField]private float timeBetweenShoot =0.1f;
    [SerializeField]private float currentTimeBetweenShoot=0f;
    
    [SerializeField] private int score=2;

    private float _offset = 90f;
   
    public delegate void AddScore(int scor);

    public static event AddScore AddScore1;
    private void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector2 difference = hero.transform.position - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        gun.transform.rotation= Quaternion.Euler(0f,0f,-rotate + _offset );
        
        Debug.DrawRay(shootPoint.transform.position, difference*10, Color.red);
        RaycastHit2D hit= Physics2D.Raycast(shootPoint.transform.position, difference);

        if (hit.collider.CompareTag("Player"))
        {
            if (currentTimeBetweenShoot <= 0)
            {
                Instantiate(bullet, shootPoint.transform.position, transform.rotation);
                currentTimeBetweenShoot = timeBetweenShoot;
            }
                
        }

        currentTimeBetweenShoot -= Time.deltaTime;
    }
    protected override void Death()
    {
        AddScore1(score);
        base.Death();
    }
}
