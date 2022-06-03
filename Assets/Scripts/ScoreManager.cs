using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] BasketballCourt basketballCourt;
    [SerializeField] UIController uIController;
    [SerializeField] float timer;
    bool isGameActive;
    public void UpdatePlayerScore(int score)
    {
        uIController.UpdatePlayerScore(score);
    }
    public void UpdateOpponentScore(int score)
    {
        uIController.UpdateOpponentScore(score);
    }

    public void UpdateTimer()
    {
        uIController.UpdateTimer(timer);
    }

    private void Update()
    {
        if (isGameActive)
        {
            timer -= Time.deltaTime;
            UpdateTimer();
            if (timer < 0)
            {

                gameManager.GameOver();
            }
        }
    }
    public void Initialize()
    {
        isGameActive = true;
    }
}
