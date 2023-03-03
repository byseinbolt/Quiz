using System;
using System.Collections.Generic;
using GameData;
using IngameStateMachine;
using JetBrains.Annotations;
using UI;
using UnityEngine;

using States;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private LevelController _levelController;
    
    [SerializeField]
    private DataProvider _dataProvider;
    
    private IReadOnlyList<GameItem> _selectedSet;
    private int _currentLevelIndex;
    private StateMachine _stateMachine;

    private void Start()
    {
        var states = new IState[]
        {
            GetComponent<StartGameState>(),
            GetComponent<GameState>(),
            GetComponent<LevelCompletedState>(),
            GetComponent<GameOverState>()
        };
        _stateMachine = new StateMachine(states);
        _stateMachine.Initialize();
        _stateMachine.Enter<StartGameState>();
        
    }
    
    [UsedImplicitly]
    // from UnityEvent in startScreen
    public void OnGameSetInstanceClicked(GameSetView setView)
    {
        _selectedSet = setView.GetSetItems();
        var currentLevel = _dataProvider.GetLevel(_currentLevelIndex);
        _levelController.StartLevel(_selectedSet, currentLevel);
        _stateMachine.Enter<GameState>();
    }
    
    [UsedImplicitly]
    // from click on NextLevel in LevelCompletedScreen
    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        var currentLevel = _dataProvider.GetLevel(_currentLevelIndex);
        _levelController.StartLevel(_selectedSet,currentLevel);
        _stateMachine.Enter<GameState>();
    }

    [UsedImplicitly]
    // from click on MainMenuButton
    public void RestartGame()
    {
        _currentLevelIndex = 0;
        _stateMachine.Enter<StartGameState>();
    }
    
    [UsedImplicitly]
    // calls from UnityEvent in LevelController 
    public void CheckGameOver(Cell cell)
    {
        if (IsLastLevel())
        {
            _stateMachine.Enter<GameOverState>();
        }
        else
        {
            _stateMachine.Enter<LevelCompletedState>();
        }
    }

    private bool IsLastLevel()
    {
        return _currentLevelIndex == _dataProvider.LevelsCount() - 1;
    }
}


