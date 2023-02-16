using System;
using System.Collections.Generic;
using GameData;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    public event Action SetSelected;
    public event Action LevelCompleted;
    
    //TODO:подумать над названием ивента
    [SerializeField]
    private UnityEvent<string> _setGoal;
    
    private CellSpawner _cellSpawner;
    private Dictionary<string,IReadOnlyList<GameItem>> _gameSetsData;
    private List<LevelData> _levelsData;
    private GameItem _goalItem;

    private void Awake()
    {
        _cellSpawner = GetComponent<CellSpawner>();
        _gameSetsData = new Dictionary<string,IReadOnlyList<GameItem>>();
        _levelsData = new List<LevelData>();
    }

    private void Start()
    {
        _cellSpawner.OnClicked += OnCellClicked;
    }
    
    public void Initialize(DataProvider dataProvider)
    {
        foreach (var gameSetData in dataProvider.GameSetData)
        {
            var gameSetName = gameSetData.GameSetName;
            var gameSetItems = gameSetData.GameItems;
            _gameSetsData.Add(gameSetName,gameSetItems);
        }

        foreach (var levelData in dataProvider.GameLevelSettings.Levels)
        {
            _levelsData.Add(levelData);
        }
    }

    [UsedImplicitly]
    // from UnityEvent in startScreenController
    public void OnGameSetInstanceClicked(GameSetView setView)
    {
        if (_gameSetsData.ContainsKey(setView.GameSetName))
        {
            var selectedGameSet = _gameSetsData[setView.GameSetName];
            StartLevel(selectedGameSet);
        }
        SetSelected?.Invoke();
    }

    private void StartLevel(IReadOnlyList<GameItem> selectedGameSet)
    {
        _cellSpawner.Spawn(selectedGameSet);
        _goalItem = GetGoal();
        _setGoal.Invoke(_goalItem.ItemName);
    }
    
    private void OnCellClicked(Cell cell)
    {
        if (cell.Image.sprite == _goalItem.ItemView)
        {
            Debug.Log("WIN");
            LevelCompleted?.Invoke();
        }
    }
    private GameItem GetGoal()
    {
        var randomUsedGameItemIndex = Random.Range(0, _cellSpawner.OneLevelUsedGameItems.Count);
        return _cellSpawner.OneLevelUsedGameItems[randomUsedGameItemIndex];
    }
    
    private void OnDestroy()
    {
        _cellSpawner.OnClicked -= OnCellClicked;
    }
}