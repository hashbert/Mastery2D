using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform _movingSprite;
    [SerializeField] private float _speed =1;
    private float _positionPercent;
    private int _direction = 1;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(_start.position, _end.position);
        float constantSpeed = _speed / distance;

        _positionPercent += Time.deltaTime * _direction * constantSpeed;
        _movingSprite.position = Vector3.Lerp(_start.position, _end.position, _positionPercent );

        if (_positionPercent >=1 && _direction == 1)
        {
            _direction = -1;
        }
        else if (_positionPercent <=0 && _direction == -1)
        {
            _direction = 1;
        }
    }
}
