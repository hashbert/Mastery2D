using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private IMove _IMove;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _IMove = GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = _IMove.Speed;
        _animator.SetFloat("Speed", speed);
    }
}
