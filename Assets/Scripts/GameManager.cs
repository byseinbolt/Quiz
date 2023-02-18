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
    private DataProvider _dataProvider;
    
    [SerializeField]
    private StartScreenView _startScreenView;
    [SerializeField]
    private GameScreenView _gameScreenView;
    [SerializeField]
    private LevelCompletedScreenView _levelCompletedScreenView;
    [SerializeField]
    private GameOverScreenView _gameOverScreenView;
    
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
    // при клике на кнопку NextLevel в LevelCompletedScreen
    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        var currentLevel = _dataProvider.GameLevelSettings.Levels[_currentLevelIndex];
        _levelController.StartLevel(_selectedSet,currentLevel);
        _levelCompletedScreenView.ScreenFadeOut();
    }

    [UsedImplicitly]
    // при клике на RestartButton
    public void RestartGame()
    {
        _currentLevelIndex = 0;
        _gameOverScreenView.ScreenFadeOut();
        _startScreenView.ScreenFadeIn();
    }
    
    // TODO: название не очень, 
    [UsedImplicitly]
    // пока вызывается через unityevent levelCompletedScreenView
    public void CheckLevel(Cell cell)
    {
        if (IsNoMoreLevels())
        {
            _gameOverScreenView.ScreenFadeIn();
            _gameScreenView.ScreenFadeOut();
        }
        else
        {
            _gameScreenView.ScreenFadeOut();
            _levelCompletedScreenView.ScreenFadeIn();
        }
    }

    private bool IsNoMoreLevels()
    {
        return _currentLevelIndex == _dataProvider.GameLevelSettings.Levels.Length - 1;
    }
}


