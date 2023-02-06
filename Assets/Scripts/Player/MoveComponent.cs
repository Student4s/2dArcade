using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;

    [SerializeField] private float JumpForce = 1000f;
    [SerializeField] private bool IsGround = true;
    [SerializeField] private int JumpCounter = 2;
    private int MaxJumpCount = 2;

    [SerializeField] private GameObject menu;
    [SerializeField] private bool isMenu;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direct = new Vector2();
        direct.x = Input.GetAxis("Horizontal");
        rb.AddForce(direct * speed);

        if (IsGround && direct.x == 0)
            rb.velocity = Vector2.zero;

        if (IsGround)
            JumpCounter = MaxJumpCount;

        if (Input.GetKeyDown(KeyCode.Space) && JumpCounter > 0)
        {
            JumpCounter -= 1;
            IsGround = false;
            rb.AddForce(Vector2.up * JumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenu = !isMenu;
            menu.SetActive(isMenu);
        }
            
        
        
    }

    void OnCollisionEnter2D(Collision2D Obj)
    {
        IsGround = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        IsGround = false;
    }
}