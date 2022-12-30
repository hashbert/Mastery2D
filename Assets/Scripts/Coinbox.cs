using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinbox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enabledSprite;
    [SerializeField] private SpriteRenderer _disabledSprite;
    [SerializeField] private int _totalCoins = 1;
    private int _remainingCoins;
    private void Awake()
    {
        _remainingCoins = _totalCoins;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<PlayerMovementController>();
        if (_remainingCoins > 0 && player != null)
        {
            GameManager.Instance.AddCoin();
            _remainingCoins--;

            if (_remainingCoins <= 0)
            {
                _enabledSprite.enabled = false;
                _disabledSprite.enabled = true;
            }
        }
    }
}
