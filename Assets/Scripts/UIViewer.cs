using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIViewer : MonoBehaviour
{

    [SerializeField] Button playButton;
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI opponentScoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI winnerText;
    public void Initialize()
    {
      
        playButton.gameObject.SetActive(false);
        UpdateOpponentScoreText(0);
        UpdatePlayerScoreText(0);
    }

    public void UpdatePlayerScoreText(int num)
    {
        playerScoreText.text = "Player Score " + num.ToString();
    }
    public void UpdateOpponentScoreText(int num)
    {
        opponentScoreText.text = "Opponent Score " + num.ToString();
    }

    public void UpdateTimerText(float num)
    {
        timerText.text = "Time : " + Mathf.FloorToInt(num).ToString();
    }

    public void LoadWinnerText()
    {

    }
}
