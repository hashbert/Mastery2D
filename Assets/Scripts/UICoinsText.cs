using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    private TextMeshProUGUI _tmText;

    private void Awake()
    {
        _tmText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += HandleCoinsChanged;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnCoinsChanged -= HandleCoinsChanged;
    }

    private void HandleCoinsChanged(int coins)
    {
        _tmText.text = coins.ToString();
    }
}
