using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform _sawBladeSprite;
    [SerializeField] private float _speed =1;
    private float _positionPercent;
    private int _direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(_start.position, _end.position);
        float constantSpeed = _speed / distance;

        _positionPercent += Time.deltaTime * _direction * constantSpeed;
        _sawBladeSprite.position = Vector3.Lerp(_start.position, _end.position, _positionPercent );

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
