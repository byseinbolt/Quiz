using System.Collections.Generic;
using GameData;
using JetBrains.Annotations;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UiController _uiController;

    [SerializeField]
    private LevelController _levelController;

    [SerializeField]
    private ScreenChanger _screenChanger;

    [SerializeField]
    private DataProvider _dataProvider;

    private HashSet<LevelData> _completedLevels = new();
    private IReadOnlyList<GameItem> _selectedSet;
    private int _currentLevelIndex;

    private void Start()
    {
        _uiController.Initialize(_dataProvider);
        _levelController.LevelCompleted += _screenChanger.ShowLevelCompletedScreen;
    }

    private void OnDestroy()
    {
        _levelController.LevelCompleted -= _screenChanger.ShowLevelCompletedScreen;
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
                _completedLevels.Add(currentLevel);
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
}