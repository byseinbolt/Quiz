using System.Collections.Generic;
using GameData;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private LevelController _levelController;

    [SerializeField]
    private ScreenChanger _screenChanger;

    [SerializeField]
    private DataProvider _dataProvider;
    
    [SerializeField]
    private StartScreenController _startScreenController;
    
    private IReadOnlyList<GameItem> _selectedSet;
    private int _currentLevelIndex;

    private void Start()
    {
        _startScreenController.Initialize(_dataProvider.GameSetData);
        _levelController.LevelCompleted += CheckLevel;
    }

    private void OnDestroy()
    {
        _levelController.LevelCompleted -= CheckLevel;
    }
    
    [UsedImplicitly]
    // from UnityEvent in startScreenController
    public void OnGameSetInstanceClicked(GameSetView setView)
    {
        foreach (var gameSetData in _dataProvider.GameSetData)
        {
            if (gameSetData.GameSetName == setView.GameSetName)
            {
                _selectedSet = gameSetData.GameItems;
                var currentLevel = _dataProvider.GameLevelSettings.Levels[_currentLevelIndex];
                _levelController.StartLevel(_selectedSet, currentLevel);
            }
        }
        _screenChanger.ShowGameScreen();
    }
    
    [UsedImplicitly]
    // при клике на кнопку NextLevel в LevelCompletedScreen
    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        var currentLevel = _dataProvider.GameLevelSettings.Levels[_currentLevelIndex];
        _levelController.StartLevel(_selectedSet,currentLevel);
    }

    [UsedImplicitly]
    // при клике на RestartButton
    public void RestartGame()
    {
        _currentLevelIndex = 0;
        _screenChanger.ShowStartScreen();
    }
    
    // TODO: название не очень
    private void CheckLevel()
    {
        if (IsNoMoreLevels())
        {
            _screenChanger.ShowGameOverScreen();
        }
        else
        {
            _screenChanger.ShowLevelCompletedScreen();
        }
    }

    private bool IsNoMoreLevels()
    {
        return _currentLevelIndex == _dataProvider.GameLevelSettings.Levels.Length - 1;
    }
}


