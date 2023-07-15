using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLives : MonoBehaviour
{
    TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("ShowLivesText", 0, 0.1f);
    }

    void ShowLivesText()
    {
        _text.text = $"Lives: {PlayerHealth.playerHealth.Lives}";
    }
}
