using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private float _maxDistance = 0.1f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private bool _isGrounded;

    void Update()
    {
        CheckFootForGrounding(_leftFoot);
        if (_isGrounded == false)
        {
            CheckFootForGrounding(_rightFoot); ;
        }
        
    }

    private void CheckFootForGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, Vector2.down, _maxDistance, _layerMask);
        Debug.DrawRay(foot.position, Vector3.down * _maxDistance, Color.red);
        if (raycastHit.collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}
