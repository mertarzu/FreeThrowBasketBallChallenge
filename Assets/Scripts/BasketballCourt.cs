using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballCourt : MonoBehaviour
{
  
    [SerializeField] BasketballFloorParent basketFloorPrefab;
    [SerializeField] ScoreManager scoreManager;

    BasketballFloorParent basketballFloorParent;
    public BasketballHoop PlayerHoop => basketballFloorParent.PlayerHoop;
    public Transform PlayerReference => basketballFloorParent.PlayerReference;
    public List<Transform> PlayerTransforms => basketballFloorParent.PlayerTransforms;

    public BasketballHoop OpponentHoop => basketballFloorParent.OpponentHoop;
    public Transform OpponentReference => basketballFloorParent.OpponentReference;
    public List<Transform> OpponentTransforms => basketballFloorParent.OpponentTransforms;



    public void Initialize()
    {
        basketballFloorParent = Instantiate(basketFloorPrefab);
        basketballFloorParent.transform.SetParent(transform, true);
        basketballFloorParent.Initialize();
        PlayerHoop.OnScoreChange += OnPlayerScoreChange;
        OpponentHoop.OnScoreChange += OnOpponentScoreChange;
        scoreManager.Initialize();
    }

   void OnPlayerScoreChange(int score)
    {
        scoreManager.UpdatePlayerScore(score);
    }

    void OnOpponentScoreChange(int score)
    {
        scoreManager.UpdateOpponentScore(score);
    }
}
