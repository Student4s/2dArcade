using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Hitable
{
    [SerializeField] private float speed;
    [SerializeField] private int score;
    [SerializeField] private Transform FirstPoint;
    [SerializeField] private Transform SecondPoint;

    private Vector3 fp;
    private Vector3 sec;
    [SerializeField]private Vector3 spot;
    [SerializeField] private SpriteRenderer sp;

    public delegate void AddScore(int scor);

    public static event AddScore AddScore1;

    void Start()
    {
        
        sp = GetComponent<SpriteRenderer>();
        sec = SecondPoint.position;
        fp = FirstPoint.position;
        spot = fp;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, spot, speed * Time.deltaTime);
        
        if ( (fp - transform.position).sqrMagnitude< 1f)
        {
            spot = sec;
            sp.flipX = true;
        }

        if ((sec - transform.position).sqrMagnitude< 1f)
        {
            spot = fp;
            sp.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Player"))
        {
            Obj.collider.GetComponent<Hitable>().TakeDamage(10);
            gameObject.SetActive(false);
        }
    }

    protected override void Death()
    {
        AddScore1(score);
        base.Death();
    }
}