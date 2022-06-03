using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BasketballHoop : MonoBehaviour
{
    public Action<int> OnScoreChange;
    int score;
    private void OnTriggerEnter(Collider other)
    {
        score++;
        OnScoreChange(score);
    }
}
