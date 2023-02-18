using System;
using System.Collections;
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
         StartCoroutine(_cellSpawner.Spawn(selectedGameSet, currentLevel));
        _goalItem = GetGoal();
        _currentGoalItem = _goalItem;
        _goalSelected.Invoke(_goalItem.ItemName);
        
    }
    
    private void OnCellClicked(Cell cell)
    {
        if (cell.Image.sprite == _goalItem.ItemView)
        {
            _levelCompleted.Invoke(cell);
        }
        else
        {
            var button = cell.GetComponent<Button>();
            button.interactable = false;
            StartCoroutine(PlayRotationAnimation(cell, button));
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

    private IEnumerator PlayRotationAnimation(Cell cell, Button button)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(cell.Image.rectTransform.DORotate(new Vector3(0, 180, 0), 0.5f).SetEase(Ease.InBounce))
            .SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(1f);
        button.interactable = true;
    }
    
}