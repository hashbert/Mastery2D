using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoinImage : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        GameManager.Instance.OnCoinsChanged += PulseCoinImage;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= PulseCoinImage;
    }
    private void PulseCoinImage(int coin)
    {
        _animator.SetTrigger("Pulse");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
