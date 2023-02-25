using System.Collections.Generic;
using DG.Tweening;
using GameData;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilities;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Cell> _levelCompleted;
    
    [SerializeField]
    private UnityEvent<string> _goalSelected;

    private CellSpawner _cellSpawner;
    private GameItem _goalItem;
    private IReadOnlyList<GameItem> _levelItems;

    private void Awake()
    {
        _cellSpawner = GetComponent<CellSpawner>();
        _cellSpawner.OnClicked += OnCellClicked;
    }
    
    public void StartLevel(IReadOnlyList<GameItem> selectedGameSet, LevelData currentLevel)
    {
        _levelItems = selectedGameSet.GetRandomItems(currentLevel.LevelElementsCount);
        _cellSpawner.Spawn(_levelItems);
        
        _goalItem = _levelItems.GetRandomItem(_goalItem);
        _goalSelected.Invoke(_goalItem.Name);
    }
    
    private void OnCellClicked(Cell cell)
    {
        var button = cell.GetComponent<Button>();
        
        if (cell.Image.sprite == _goalItem.View)
        {
            // TODO: подумать над названием метода
            PlayDisappearAnimation(cell, button);
        }
        else
        {
            PlayRotationAnimation(cell, button);
        }
    }
    
    private void OnDestroy()
    {
        _cellSpawner.OnClicked -= OnCellClicked;
    }

    private void PlayRotationAnimation(Cell cell, Button button)
    {
        button.interactable = false;
        cell.Image.rectTransform.DORotate(new Vector3(0, 180, 0), 0.5f)
            .SetEase(Ease.InBounce)
            .SetLoops(2, LoopType.Yoyo)
            .OnComplete(() => button.interactable = true);
    }
    
  private void PlayDisappearAnimation(Cell cell, Button button)
  {
      var sequence = DOTween.Sequence();
      
      sequence.AppendCallback(() => button.interactable = false)
          .Append(cell.Image.rectTransform.DOScale(Vector3.zero, 1.5f).SetEase(Ease.InBounce))
          .AppendCallback(() => _levelCompleted.Invoke(cell))
          .AppendInterval(0.5f)
          .AppendCallback(() => _cellSpawner.HidePreviousLevelCells())
          .Append(cell.Image.rectTransform.DOScale(Vector3.one, 0.1f))
          .AppendCallback(() => button.interactable = true);
  }
}