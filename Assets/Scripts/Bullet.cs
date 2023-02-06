using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour

{
    private IObjectPool<Bullet> _pool;

    public void SetPool(IObjectPool<Bullet> pool) => _pool = pool;

    public float speed = 1f;
    public float lifeTime = 1f;
    public float damage = 1f;
    
    private void Start()
    {

    }

    private void Update()
    {
       lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            if (_pool != null)
            {
                lifeTime = 1f;
                _pool.Release(this);
            }
            else
                Destroy(gameObject);
        }
        transform.Translate(Vector2.right*speed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.collider.CompareTag("Enemy"))
        {
            obj.collider.GetComponent<Hitable>().TakeDamage(damage);
            lifeTime = 1f;
            _pool.Release(this);
            return;
        }
        
        lifeTime = 1f; 
        _pool.Release(this);
  
    }
}
