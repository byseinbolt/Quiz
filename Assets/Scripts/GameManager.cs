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

    private StateMachine _fsm;
    
    private void Start()
    { 
        _fsm = new StateMachine();
        
        _fsm.AddState("StartGameState", new StartGameState(_startScreen,_dataProvider));
        _fsm.AddState("GameState", new GameState(_gameScreen, _levelController));
        _fsm.AddState("LevelCompletedState", new LevelCompletedState(_levelCompletedScreen));
        _fsm.AddState("GameOverState", new GameOverState(_levelCompletedScreen));
        
        _fsm.AddTriggerTransition("OnSetSelected",
            "StartGameState",  
            "GameState");
        
        _fsm.AddTriggerTransition("NotLastLevel",
            "GameState", 
            "LevelCompletedState");
        
        _fsm.AddTriggerTransition("OnNextLevelClicked",
            "LevelCompletedState",
            "GameState");
        
        _fsm.AddTriggerTransition("IsLastLevel"
            , "GameState"
            , "GameOverState");
        
        _fsm.AddTriggerTransition("OnRestartClicked",
                 "GameOverState", 
                  "StartGameState");

        _fsm.SetStartState("StartGameState");
        _fsm.Init();
       //_startScreenView.Initialize(_dataProvider.GameSetData);
       //_startScreenView.Show();
    }
    
    [UsedImplicitly]
    // from UnityEvent in startScreen
    public void OnGameSetInstanceClicked(GameSetView setView)
    {
        _fsm.Trigger("OnSetSelected");
        _selectedSet = setView.GetSetItems();
        var currentLevel = _dataProvider.GetLevel(_currentLevelIndex);
        _levelController.StartLevel(_selectedSet, currentLevel);
       
        //_startScreen.Hide();
        //_gameScreen.Show();
    }
    
    [UsedImplicitly]
    // from click on NextLevel in LevelCompletedScreen
    public void LoadNextLevel()
    {
        _fsm.Trigger("OnNextLevelClicked");
        _currentLevelIndex++;
        var currentLevel = _dataProvider.GetLevel(_currentLevelIndex);
        _levelController.StartLevel(_selectedSet,currentLevel);
        
       // _levelCompletedScreen.Hide();
       // _gameScreen.Show();
    }

    [UsedImplicitly]
    // from click on MainMenuButton
    public void RestartGame()
    {
        _fsm.Trigger("OnRestartClicked");
        _currentLevelIndex = 0;
        //_levelCompletedScreen.Hide();
        //_startScreen.Show();
    }
    
    [UsedImplicitly]
    // calls from UnityEvent in LevelController 
    public void CheckGameOver(Cell cell)
    {
        if (IsLastLevel())
        {
            _fsm.Trigger("IsLastLevel");
           // _levelCompletedScreen.Show();
           // _gameScreen.Hide();
           // _levelCompletedScreen.ShowRestartView();
        }
        else
        {
            _fsm.Trigger("NotLastLevel");
           //_gameScreen.Hide();
           //_levelCompletedScreen.Show();
           //_levelCompletedScreen.ShowNextLevelButton();
        }
    }

    private bool IsLastLevel()
    {
        return _currentLevelIndex == _dataProvider.LevelsCount() -1;
    }
}


