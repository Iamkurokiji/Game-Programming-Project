using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[requiredComponent(typeof(RigidBody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField, Range(5f, 20f)] private float speed;

    private Rigidbody2D rb2d;
    private float direction;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if(rb2d is null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector velocity = rb2d.Velocity;
        velocity.x = direction * speed;
        rb2d.velocity = velocity;
    }

    public void SetDirection(float direction)
    {
        this.direction = direction;
    }
    
}
