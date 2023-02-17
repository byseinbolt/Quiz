using System;
using System.Collections.Generic;
using DG.Tweening;
using GameData;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Cell> _levelCompleted;
    
    [SerializeField]
    private UnityEvent<string> _goalSelected;
    
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
        _goalSelected.Invoke(_goalItem.ItemName);
        
    }
    
    // TODO: возможно вызывать через юнити ивент
    private void OnCellClicked(Cell cell)
    {
        if (cell.Image.sprite == _goalItem.ItemView)
        {
            _levelCompleted.Invoke(cell);
        }
        else
        {
           PlayRotationAnimation(cell);
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

    private void PlayRotationAnimation(Cell cell)
    {
        cell.Image.rectTransform.DORotate(new Vector3(0, 180, 0), 0.5f)
            .SetEase(Ease.InBounce)
            .SetLoops(2, LoopType.Yoyo);
    }
    
}