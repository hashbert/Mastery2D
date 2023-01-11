using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _direction = Vector2.left;
    private Transform _leftPosition;
    [SerializeField] private GameObject _spawnOnStompPrefab;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer() && collision.WasTop())
        {
            HandleWalkerStomped();
        }
    }

    private void HandleWalkerStomped()
    {
        if (_spawnOnStompPrefab != null)
        {
            Instantiate(_spawnOnStompPrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _speed * Time.fixedDeltaTime);
    }
    private void LateUpdate()
    {
        if (ReachedEdge() || HitNotPlayer())
        {
            SwitchDirections();
        }
    }

    private bool HitNotPlayer()
    {
        float x = GetForwardX();
        float y = transform.position.y;
        Vector2 origin = new Vector2(x, y);
        Debug.DrawRay(origin, _direction * 0.1f);
        var hit = Physics2D.Raycast(origin, _direction, 0.1f);
        if (hit.collider == null)
        {
            return false;
        }
        if (hit.collider.isTrigger)
        {
            return false;
        }
        if (hit.collider.GetComponent<PlayerMovementController>() != null)
        {
            return false;
        }

        return true;
    }

    private bool ReachedEdge()
    {
        float x = GetForwardX();

        float y = _collider.bounds.min.y;

        Vector2 origin = new Vector2(x, y);
        Debug.DrawRay(origin, Vector2.down * 0.1f);

        var hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);
        if (hit.collider == null)
        {
            return true;
        }

        return false;
    }

    private float GetForwardX()
    {
        return _direction.x == -1 ?
                    _collider.bounds.min.x - 0.1f :
                    _collider.bounds.max.x + 0.1f;
    }

    private void SwitchDirections()
    {
        _direction *= -1;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
