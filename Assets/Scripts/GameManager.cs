using System;
using System.Collections.Generic;
using GameData;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using FSM;

public class GameManager : MonoBehaviour
{
    private StateMachine _stateMachine;
    
    [SerializeField]
    private LevelController _levelController;
    
    [SerializeField]
    private DataProvider _dataProvider;
    
    [SerializeField]
    private StartScreen _startScreenView;
    
    [SerializeField]
    private GameScreen _gameScreenView;

    [SerializeField]
    private LevelCompletedScreen _levelCompletedScreenView;
    

    private IReadOnlyList<GameItem> _selectedSet;
    private int _currentLevelIndex;

    private void Start()
    {
       _stateMachine = new StateMachine();
       _stateMachine.AddState("StartGameState",new State(
           onEnter: (state) =>  _startScreenView.Initialize(_dataProvider.GameSetData)));
      // _startScreenView.Initialize(_dataProvider.GameSetData);
       _startScreenView.Show();
       _stateMachine.SetStartState("StartGameState");
       _stateMachine.Init();
       _stateMachine.OnLogic();
    }

    [UsedImplicitly]
    // from UnityEvent in startScreenController
    public void OnGameSetInstanceClicked(GameSetView setView)
    {
        _selectedSet = setView.GetSetItems();
        var currentLevel = _dataProvider.GetLevel(_currentLevelIndex);
        _levelController.StartLevel(_selectedSet, currentLevel);
        _startScreenView.Hide();
        _gameScreenView.Show();
    }
    
    [UsedImplicitly]
    // from click on NextLevel in LevelCompletedScreen
    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        var currentLevel = _dataProvider.GetLevel(_currentLevelIndex);
        _levelController.StartLevel(_selectedSet,currentLevel);
        _levelCompletedScreenView.Hide();
        _gameScreenView.Show();
    }

    [UsedImplicitly]
    // from click on MainMenuButton
    public void RestartGame()
    {
        _currentLevelIndex = 0;
        _levelCompletedScreenView.Hide();
        _startScreenView.Show();
    }
    
    [UsedImplicitly]
    // calls from UnityEvent in LevelController 
    public void CheckGameOver(Cell cell)
    {
        if (IsLastLevel())
        {
            _levelCompletedScreenView.Show();
            _gameScreenView.Hide();
            _levelCompletedScreenView.ShowRestartView();
        }
        else
        {
            _gameScreenView.Hide();
            _levelCompletedScreenView.Show();
            _levelCompletedScreenView.ShowNextLevelButton();
        }
    }

    private bool IsLastLevel()
    {
        return _currentLevelIndex == _dataProvider.LevelsCount() -1;
    }
}


