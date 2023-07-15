using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    TextMeshProUGUI m_textUI;
    private void Awake()
    {
        m_textUI = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("ShowScoreUI",0,0.1f);
    }

    void ShowScoreUI()
    {
        m_textUI.text = $"Score: {PlayerData.Score}/{GameManager.gameManagerInstance.ScoreToWin}";
    }
}
