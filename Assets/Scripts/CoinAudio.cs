using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnCoinsChanged += PlayCoinAudio;
            //(coins) => _audioSource.Play(); could do this... but it won't deregister
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= PlayCoinAudio;
    }
    private void PlayCoinAudio(int coins)
    {
        _audioSource.Play();
    }

}
