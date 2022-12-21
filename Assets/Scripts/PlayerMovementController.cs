using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpForce = 400f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement * Time.deltaTime * _moveSpeed;

        if (Input.GetButtonDown("Fire1"))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}
