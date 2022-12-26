using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovementController _playerMovementController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovementController = GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = _playerMovementController.Speed;
        _animator.SetFloat("Speed", speed);
    }
}
