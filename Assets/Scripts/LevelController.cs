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
    public event Action LevelCompleted;

    public GameItem GoalItem { get; private set; }

    //TODO:подумать над названием ивента
    [SerializeField]
    private UnityEvent<string> _setGoal;
    
    private CellSpawner _cellSpawner;
    private GameItem _currentGoalItem;

    private void Awake()
    {
        _cellSpawner = GetComponent<CellSpawner>();
    }

    private void Start()
    {
        _cellSpawner.OnClicked += OnCellClicked;
    }
    
    public void StartLevel(IReadOnlyList<GameItem> selectedGameSet, LevelData currentLevel)
    {
        _cellSpawner.Spawn(selectedGameSet, currentLevel);
        GoalItem = GetGoal();
        _currentGoalItem = GoalItem;
        _setGoal.Invoke(GoalItem.ItemName);
        
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
        while (_currentGoalItem == _cellSpawner.OneLevelUsedGameItems[randomUsedGameItemIndex])
        {
            randomUsedGameItemIndex = Random.Range(0, _cellSpawner.OneLevelUsedGameItems.Count);
        }
        return _cellSpawner.OneLevelUsedGameItems[randomUsedGameItemIndex];
    }
    
    private void OnDestroy()
    {
        _cellSpawner.OnClicked -= OnCellClicked;
    }
}