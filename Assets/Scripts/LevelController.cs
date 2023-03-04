using System;
using System.Collections.Generic;
using DG.Tweening;
using Events;
using GameData;
using SimpleEventBus.Disposables;
using SimpleEventBus.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilities;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private DataProvider _dataProvider;
    
    private CellSpawner _cellSpawner;
    private GameItem _goalItem;
    private IReadOnlyList<GameItem> _selectedSetItems;
    private IReadOnlyList<GameItem> _currentLevelItems;
    private LevelData _currentLevel;
    private CompositeDisposable _subscriptions;

    private void Awake()
    {
        _cellSpawner = GetComponent<CellSpawner>();

        _subscriptions = new CompositeDisposable
        {
            EventStreams.Game.Subscribe<SetSelectedEvent>(OnSetSelected),
            EventStreams.Game.Subscribe<NextLevelButtonClickedEvent>(OnNextLevelButtonClicked),
            EventStreams.Game.Subscribe<CellClickedEvent>(OnCellClicked)
        };
    }
    
    public void StartLevel()
    {
        _cellSpawner.Spawn(_currentLevelItems);
        
        _goalItem = _currentLevelItems.GetRandomItem(_goalItem);
        EventStreams.Game.Publish(new GoalSelectedEvent(_goalItem.Name));
    }
    
    private void OnCellClicked(CellClickedEvent eventData)
    {
        var cell = eventData.Cell;
        var button = cell.Button;
        
        if (cell.Image.sprite == _goalItem.View)
        {
            LevelCompleted(cell, button);
        }
        else
        {
            PlayRotationAnimation(cell, button);
        }
    }
    
    private void LevelCompleted(Cell cell, Button button)
    {
        var sequence = DOTween.Sequence();
      
        sequence.AppendCallback(() => button.interactable = false)
            .Append(cell.Image.rectTransform.DOScale(Vector3.zero, 1.5f).SetEase(Ease.InBounce))
            .AppendCallback(() => EventStreams.Game.Publish(new LevelCompletedEvent(cell)))
            .AppendInterval(0.5f)
            .AppendCallback(() => _cellSpawner.HidePreviousLevelCells())
            .Append(cell.Image.rectTransform.DOScale(Vector3.one, 0.1f))
            .AppendCallback(() => button.interactable = true);
    }
    
    private void OnNextLevelButtonClicked(NextLevelButtonClickedEvent eventData)
    {
        _currentLevelItems = GetLevelItems(eventData.LevelIndex);
    }

    private void OnSetSelected(SetSelectedEvent eventData)
    {
        _selectedSetItems = eventData.SetView.GetSetItems();
        _currentLevelItems = GetLevelItems(eventData.LevelIndex);
    }

    private IReadOnlyList<GameItem> GetLevelItems(int levelIndex)
    {
        _currentLevel = _dataProvider.GetLevel(levelIndex);
         return _selectedSetItems.GetRandomItems(_currentLevel.ElementsCount);
    }
    
    private void PlayRotationAnimation(Cell cell, Button button)
    {
        button.interactable = false;
        cell.Image.rectTransform.DORotate(new Vector3(0, 180, 0), 0.5f)
            .SetEase(Ease.InBounce)
            .SetLoops(2, LoopType.Yoyo)
            .OnComplete(() => button.interactable = true);
    }
    
    private void OnDestroy()
    {
        _subscriptions?.Dispose();
    }
}