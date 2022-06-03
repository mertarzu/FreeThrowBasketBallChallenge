using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{  
    [SerializeField] UIController uiController;
    [SerializeField] Player player;
    [SerializeField] Opponent opponent;
    [SerializeField] OpponentDecisionMaker opponentDecisionMaker;
    [SerializeField] SelectionInputController selectionInputController;
    [SerializeField] TargetInputController targetInputController;
    [SerializeField] BasketballCourt basketballCourt;
    //GameState gameState;
    //public GameState GameState 
    //{
    //    get => gameState;
    //    set
    //    {
    //        gameState = value;
    //        OnGameStateChange?.Invoke(gameState);
    //    }
    //}
    //public static event Action<GameState> OnGameStateChange;

    //private void Start()
    //{
    //    GameState = GameState.Loading;
    //}

    void InitializeUIController()
    {
        uiController.Initialize();
    }

    void InitializePlayer()
    {
        player.Initialize();
    }

    void InitializeOpponent()
    {
        opponent.Initialize();
    }
    void InitializeOpponentAI()
    {
        opponentDecisionMaker.Initialize();
    }

    void InitializeSelectionInputController()
    {
        selectionInputController.Initialize();
    }

    void InitializeTargetInputController()
    {
        targetInputController.Initialize();
    }

    void InitializeBasketballCourt()
    {
        basketballCourt.Initialize();
    }

    public void StartGame()
    {
        InitializeBasketballCourt();
        InitializeUIController();
        InitializePlayer();
        InitializeOpponent();
        InitializeOpponentAI();
        InitializeSelectionInputController();
        InitializeTargetInputController();
      
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


//public enum GameState
//{
//    Loading,
//    Idle,
//    GamePlay,
//    GameOver
//}