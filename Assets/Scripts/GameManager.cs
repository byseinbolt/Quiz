using System.Collections.Generic;
using GameData;
using JetBrains.Annotations;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private LevelController _levelController;
    
    [SerializeField]
    private DataProvider _dataProvider;
    
    [SerializeField]
    private StartScreenView _startScreenView;
    
    [SerializeField]
    private GameScreenView _gameScreenView;
    
    [SerializeField]
    private LevelCompletedScreenView _levelCompletedScreenView;
    
    private IReadOnlyList<GameItem> _selectedSet;
    private int _currentLevelIndex;

    private void Start()
    {
        _startScreenView.Initialize(_dataProvider.GameSetData);
       _startScreenView.ScreenFadeIn();
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
        _startScreenView.ScreenFadeOut();
        _gameScreenView.ScreenFadeIn();
    }
    
    [UsedImplicitly]
    // from click on NextLevel in LevelCompletedScreen
    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        var currentLevel = _dataProvider.GameLevelSettings.Levels[_currentLevelIndex];
        _levelController.StartLevel(_selectedSet,currentLevel);
        _levelCompletedScreenView.ScreenFadeOut();
        _gameScreenView.ScreenFadeIn();
    }

    [UsedImplicitly]
    // from click on MainMenuButton
    public void RestartGame()
    {
        _currentLevelIndex = 0;
        _levelCompletedScreenView.ScreenFadeOut();
        _startScreenView.ScreenFadeIn();
    }
    
    [UsedImplicitly]
    // calls from UnityEvent in LevelController 
    public void CheckGameOver(Cell cell)
    {
        if (IsNoMoreLevels())
        {
            _levelCompletedScreenView.ScreenFadeIn();
            _gameScreenView.ScreenFadeOut();
            _levelCompletedScreenView.ShowRestartView();
        }
        else
        {
            _gameScreenView.ScreenFadeOut();
            _levelCompletedScreenView.ScreenFadeIn();
            _levelCompletedScreenView.ShowNextLevelButton();
        }
    }

    private bool IsNoMoreLevels()
    {
        return _currentLevelIndex == _dataProvider.GameLevelSettings.Levels.Length - 1;
    }
}


