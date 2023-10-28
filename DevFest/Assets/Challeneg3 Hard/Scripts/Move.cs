using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Vector2 mousePose;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        mousePose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Vector2 lookdir = mousePose - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

}
