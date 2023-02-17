using System;
using System.Collections.Generic;
using GameData;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    public event Action LevelCompleted;

    //TODO:подумать над названием ивента
    [SerializeField]
    private UnityEvent<string> _setGoal;

    [SerializeField]
    private Image _image;
    
    private CellSpawner _cellSpawner;
    private GameItem _currentGoalItem;
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
        _currentGoalItem = _goalItem;
        _setGoal.Invoke(_goalItem.ItemName);
    }
    
    private void OnCellClicked(Cell cell)
    {
        if (cell.Image.sprite == _goalItem.ItemView)
        {
            _image.sprite = cell.Image.sprite;
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