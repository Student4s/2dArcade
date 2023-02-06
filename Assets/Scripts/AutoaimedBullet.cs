using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class AutoaimedBullet : MonoBehaviour
{

    [SerializeField] private GameObject _hero;
    private float _offset = -90f;
    [SerializeField] private float speed;


    private void Start()
    {
        _hero = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _hero.transform.position, speed * Time.deltaTime);
        
        Vector2 difference = _hero.transform.position - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + _offset );
    }
    
    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Player"))
            Obj.collider.GetComponent<PlayerStats>().TakeDamage(2);
        Destroy(gameObject);
    }
}
