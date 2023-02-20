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
    private StartScreen _startScreenView;
    
    [SerializeField]
    private GameScreen _gameScreenView;

    [SerializeField]
    private LevelCompletedScreen _levelCompletedScreenView;
    
    private IReadOnlyList<GameItem> _selectedSet;
    private int _currentLevelIndex;

    private void Start()
    { 
       _startScreenView.Initialize(_dataProvider.GameSetData);
       _startScreenView.Show();
    }
    
    [UsedImplicitly]
    // from UnityEvent in startScreenController
    public void OnGameSetInstanceClicked(GameSetView setViewView)
    {
        var currentLevel = _dataProvider.GetLevel(_currentLevelIndex);
        _levelController.StartLevel(setViewView.GameSetData.GameItems, currentLevel);
        _startScreenView.Hide();
        _gameScreenView.Show();
    }
    
    [UsedImplicitly]
    // from click on NextLevel in LevelCompletedScreen
    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        var currentLevel = _dataProvider.GameLevelSettings.Levels[_currentLevelIndex];
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
        return _currentLevelIndex == _dataProvider.GameLevelSettings.Levels.Length - 1;
    }
}


