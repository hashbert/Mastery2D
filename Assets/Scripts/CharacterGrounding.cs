using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    [SerializeField] private float _maxDistance = 0.1f;
    [SerializeField] private LayerMask _layerMask;
    public bool IsGrounded { get; private set; }
    private Transform _groundedObject;
    public Vector3? _groundedObjectLastPosition;

    void Update()
    {
        foreach (var position in _positions)
        {
            CheckFootForGrounding(position);
            if (IsGrounded) 
                break;
        }
        StickToMovingObjects();
    }

    private void StickToMovingObjects()
    {
        if (_groundedObject != null)
        {
            if (_groundedObjectLastPosition.HasValue &&
                _groundedObjectLastPosition.Value != _groundedObject.position)
            {
                Vector3 delta = _groundedObject.position - _groundedObjectLastPosition.Value;
                transform.position += delta;
            }
            _groundedObjectLastPosition = _groundedObject.position;
        }
        else
        {
            _groundedObjectLastPosition = null;
        }
    }

    private void CheckFootForGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, Vector2.down, _maxDistance, _layerMask);
        Debug.DrawRay(foot.position, Vector3.down * _maxDistance, Color.red);
        if (raycastHit.collider != null)
        {
            if (_groundedObject != raycastHit.collider.transform)
            {
                _groundedObject = raycastHit.collider.transform;
                IsGrounded = true;
                _groundedObjectLastPosition = _groundedObject.position;
            }
            else
            {
                _groundedObject = null;
                IsGrounded = false;
            }
        }
    }
}
