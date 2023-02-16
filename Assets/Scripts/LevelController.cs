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
    
    //TODO:подумать над названием ивента
    [SerializeField]
    private UnityEvent<string> _setGoal;
    
    private CellSpawner _cellSpawner;
    private GameItem _goalItem;

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