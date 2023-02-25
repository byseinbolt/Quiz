using System;
using System.Collections.Generic;
using GameData;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using FSM;
using States;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private LevelController _levelController;
    
    [SerializeField]
    private DataProvider _dataProvider;
    
    [SerializeField]
    private StartScreen _startScreen;
    
    [SerializeField]
    private GameScreen _gameScreen;

    [SerializeField]
    private LevelCompletedScreen _levelCompletedScreen;
    
    private IReadOnlyList<GameItem> _selectedSet;
    private int _currentLevelIndex;

    private StateMachine _stateMachine;

    private void Start()
    { 
        _stateMachine = new StateMachine();

        _stateMachine.AddState("StartGameState", new StartGameState(_startScreen,_dataProvider));
        _stateMachine.AddState("GameState", new GameState(_gameScreen));
        _stateMachine.AddState("LevelCompletedState", new LevelCompletedState(_levelCompletedScreen));
        _stateMachine.AddState("GameOverState", new GameOverState(_levelCompletedScreen));
        
        _stateMachine.AddTriggerTransition("OnSetSelected",
            "StartGameState",  
            "GameState");
        
        _stateMachine.AddTriggerTransition("NotLastLevel",
            "GameState", 
            "LevelCompletedState");
        
        _stateMachine.AddTriggerTransition("OnNextLevelClicked",
            "LevelCompletedState",
            "GameState");
        
        _stateMachine.AddTriggerTransition("IsLastLevel"
            , "GameState"
            , "GameOverState");
        
        _stateMachine.AddTriggerTransition("OnRestartClicked",
                 "GameOverState", 
                  "StartGameState");

        _stateMachine.SetStartState("StartGameState"); 
        _stateMachine.Init();
    }
    
    [UsedImplicitly]
    // from UnityEvent in startScreen
    public void OnGameSetInstanceClicked(GameSetView setView)
    {
        _stateMachine.Trigger("OnSetSelected");
        _selectedSet = setView.GetSetItems();
        var currentLevel = _dataProvider.GetLevel(_currentLevelIndex);
        _levelController.StartLevel(_selectedSet, currentLevel);
    }
    
    [UsedImplicitly]
    // from click on NextLevel in LevelCompletedScreen
    public void LoadNextLevel()
    {
        _stateMachine.Trigger("OnNextLevelClicked");
        _currentLevelIndex++;
        var currentLevel = _dataProvider.GetLevel(_currentLevelIndex);
        _levelController.StartLevel(_selectedSet,currentLevel);
    }

    [UsedImplicitly]
    // from click on MainMenuButton
    public void RestartGame()
    {
        _stateMachine.Trigger("OnRestartClicked");
        _currentLevelIndex = 0;
    }
    
    [UsedImplicitly]
    // calls from UnityEvent in LevelController 
    public void CheckGameOver(Cell cell)
    {
        _stateMachine.Trigger(IsLastLevel() ? "IsLastLevel" : "NotLastLevel");
    }

    private bool IsLastLevel()
    {
        return _currentLevelIndex == _dataProvider.LevelsCount() - 1;
    }
}


