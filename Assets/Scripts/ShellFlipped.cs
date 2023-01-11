using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFlipped : MonoBehaviour
{
    [SerializeField] private float _shellSpeed = 10f;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * _shellSpeed, _rigidbody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer())
        {
            HandlePlayerCollision(collision);
        }
        else
        {
            if (collision.WasSide())
            {
                LaunchShell(collision);
                var takeShellHits = collision.collider.GetComponent<ITakeShellHits>();
                if (takeShellHits != null)
                {
                    takeShellHits.HandleShellHit(this);
                }
            }
        }
    }

    private void HandlePlayerCollision(Collision2D collision)
    {
        var playerMovementController = collision.collider.GetComponent<PlayerMovementController>();
        if (_direction.magnitude == 0)
        {
            LaunchShell(collision);
            if (collision.WasTop())
                playerMovementController.Bounce();
        }
        else
        {
            if (collision.WasTop())
            {
                _direction = Vector2.zero;
                playerMovementController.Bounce();
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void LaunchShell(Collision2D collision)
    {
        float floatDirection = collision.contacts[0].normal.x > 0 ? 1f : -1f;
        _direction = Vector2.right * floatDirection;
    }
}
