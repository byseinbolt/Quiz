using System;
using System.Collections.Generic;
using GameData;
using UI;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    public event Action SetWasSelected;
    public event Action LevelCompleted;
    public GameItem GoalItem { get; private set; }
    
    //TODO:подумать над названием евенту
    [SerializeField]
    private UnityEvent _setGoal;

    //TODO: подумать над прокидванием подписания ивента клика на игровой набор
    [SerializeField]
    private StartScreenController _startScreenController;
    
    private CellSpawner _cellSpawner;
    private Dictionary<string,IReadOnlyList<GameItem>> _gameSetsData;
    private List<LevelData> _levelsData;

    private void Awake()
    {
        _cellSpawner = GetComponent<CellSpawner>();
        _gameSetsData = new Dictionary<string,IReadOnlyList<GameItem>>();
        _levelsData = new List<LevelData>();
    }

    private void Start()
    {
        _startScreenController.OnInstanceClicked += OnGameSetInstanceClicked;
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

    private void OnGameSetInstanceClicked(GameSetView setView)
    {
        if (_gameSetsData.ContainsKey(setView.GameSetName))
        {
            StartLevel(_gameSetsData[setView.GameSetName]);
        }
        SetWasSelected?.Invoke();
    }

    private void StartLevel(IReadOnlyList<GameItem> selectedGameSet)
    {
        _cellSpawner.Initialize(selectedGameSet);
        GoalItem = GetGoal();
        _setGoal.Invoke();
    }
    
    private void OnCellClicked(Cell cell)
    {
        if (cell.Image.sprite == GoalItem.ItemView)
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
        _startScreenController.OnInstanceClicked -= OnGameSetInstanceClicked;
        _cellSpawner.OnClicked -= OnCellClicked;
    }
}