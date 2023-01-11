using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction = Vector2.left;
    private Transform _leftPosition;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _speed * Time.fixedDeltaTime);
    }
    private void LateUpdate()
    {
        if (ReachedEdge())
        {
            SwitchDirections();
        }
    }
    private bool ReachedEdge()
    {
        float x = _direction.x == -1 ?
            _collider.bounds.min.x - 0.1f :
            _collider.bounds.max.x + 0.1f;

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
    private void SwitchDirections()
    {
        _direction *= -1;
    }
}
