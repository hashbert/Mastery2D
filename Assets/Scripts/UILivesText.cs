using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI _tmproText;
    private void Awake()
    {
        _tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;
        _tmproText.text = GameManager.Instance.Lives.ToString();
    }

    private void HandleOnLivesChanged(int livesRemaining)
    {
        _tmproText.text = livesRemaining.ToString();
    }
}
