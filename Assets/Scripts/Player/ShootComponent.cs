using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ShootComponent : MonoBehaviour
{
    [SerializeField] private Bullet objToSpawn;
        
    [SerializeField]private GameObject shootPoint;
    [SerializeField] private GameObject gun;
    [SerializeField]private float timeBetweenShoot =0.1f;
    [SerializeField]private float currentTimeBetweenShoot=0f;
    private Camera cameraMain;

    private ObjectPool<Bullet> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(CreateBullet, OnTake, OnReturn);
        cameraMain = Camera.main;
    }

    void Update()
    {
        Vector2 difference = cameraMain.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        gun.transform.rotation= Quaternion.Euler(0f,0f,-rotate + 90f );
        
        if (Input.GetMouseButton(0))
            if (currentTimeBetweenShoot <= 0)
            {
                GetBullet();
                currentTimeBetweenShoot = timeBetweenShoot;
            }

        currentTimeBetweenShoot -= Time.deltaTime;
    }

    private Bullet CreateBullet()
    {
        var bullet = Instantiate(objToSpawn, shootPoint.transform.position, shootPoint.transform.rotation);
        bullet.SetPool(_pool);
        return bullet;
    }

    private void OnTake(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = shootPoint.transform.position;
        bullet.transform.rotation = shootPoint.transform.rotation;
    }

    private void OnReturn(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void GetBullet()
    {
        var bullet = _pool.Get();
    }
}
