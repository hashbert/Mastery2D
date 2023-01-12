using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpForce = 200f;
    [SerializeField] private float _wallJumpForce = 200f;
    private Rigidbody2D _rigidbody2D;
    private CharacterGrounding _characterGrounding;

    public float Speed { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _characterGrounding.IsGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            if (_characterGrounding.GroundedDirection != Vector2.down)
            {
                _rigidbody2D.AddForce(_characterGrounding.GroundedDirection * -1f * _wallJumpForce);
            }
        }
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Speed = horizontal;

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement * Time.deltaTime * _moveSpeed;
    }
    internal void Bounce()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }
}
