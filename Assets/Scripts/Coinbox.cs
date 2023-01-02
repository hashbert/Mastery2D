using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinbox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enabledSprite;
    [SerializeField] private SpriteRenderer _disabledSprite;
    [SerializeField] private int _totalCoins = 1;
    private Animator _animator;
    private int _remainingCoins;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _remainingCoins = _totalCoins;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_remainingCoins > 0 && 
            WasHitByPlayer(collision) &&
            WasHitFromBottomSide(collision))
        {
            GameManager.Instance.AddCoin();
            _remainingCoins--;
            _animator.SetTrigger("FlipCoin");

            if (_remainingCoins <= 0)
            {
                _enabledSprite.enabled = false;
                _disabledSprite.enabled = true;
            }
        }
    }

    private static bool WasHitByPlayer(Collision2D collision)
    {
        return collision.collider.GetComponent<PlayerMovementController>() != null;
    }

    private static bool WasHitFromBottomSide(Collision2D collision)
    {
        return collision.contacts[0].normal.y > 0.5;
    }
}
