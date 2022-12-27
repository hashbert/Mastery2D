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

    // Update is called once per frame
    void Update()
    {
        _tmproText.text = GameManager.Instance.Lives.ToString();
    }
}
