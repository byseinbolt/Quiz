using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using DG.Tweening;
using GameData;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

// TODO: подумать над названием класса
public class CellSpawner : MonoBehaviour
{
    public event Action<Cell> OnClicked;

    public IReadOnlyList<GameItem> OneLevelUsedGameItems => _oneLevelUsedGameItems;

    [SerializeField]
    private RectTransform _cellsSpawnPosition;
    
    [SerializeField]
    private Cell _cellPrefab;
    
    private List<GameItem> _oneLevelUsedGameItems = new();
    private List<Cell> _cells = new();

    // public void Spawn(IReadOnlyList<GameItem> selectedGameSetItems, LevelData currentLevel)
    // {
    //     DestroyPreviousLevelCells();
    //     _oneLevelUsedGameItems = new List<GameItem>();
    //     
    //     for (var i = 0; i < currentLevel.LevelElementsCount; i++)
    //     {
    //         var randomGameItem = GetRandomItem(selectedGameSetItems);
    //         
    //         if (_oneLevelUsedGameItems.Contains(randomGameItem))
    //         {
    //             i--;
    //             continue;
    //         }
    //         _oneLevelUsedGameItems.Add(randomGameItem);
    //         
    //         var cell = Instantiate(_cellPrefab, _cellsSpawnPosition);
    //         cell.SetClickCallback(value => OnClicked?.Invoke(value));
    //         cell.Initialize(randomGameItem.ItemView);
    //         _cells.Add(cell);
    //     }
    // }
    
    public IEnumerator Spawn(IReadOnlyList<GameItem> selectedGameSetItems, LevelData currentLevel)
    {
        DestroyPreviousLevelCells();
        _oneLevelUsedGameItems = new List<GameItem>();
        
        for (var i = 0; i < currentLevel.LevelElementsCount; i++)
        {
            var randomGameItem = GetRandomItem(selectedGameSetItems);
            
            if (_oneLevelUsedGameItems.Contains(randomGameItem))
            {
                i--;
                continue;
            }
            _oneLevelUsedGameItems.Add(randomGameItem);
            
            var cell = Instantiate(_cellPrefab, _cellsSpawnPosition);
            cell.SetClickCallback(value => OnClicked?.Invoke(value));
            cell.Initialize(randomGameItem.ItemView);
            _cells.Add(cell);
            
            if (currentLevel.LevelName == "Easy")
            {
                PlayAnimation(cell);
                yield return new WaitForSeconds(1f);
                cell.Image.sprite = randomGameItem.ItemView;
            }
            
        }
    }

    private void DestroyPreviousLevelCells()
    {
        if (_cells.Count == 0) return;
        
        foreach (var cell in _cells.Where(cell => cell != null))
        {
            Destroy(cell.gameObject);
        }
    }

    private GameItem GetRandomItem(IReadOnlyList<GameItem> selectedGameSetItems)
    {
        var randomElementIndex = Random.Range(0, selectedGameSetItems.Count);
        return selectedGameSetItems[randomElementIndex];
    }

    private void PlayAnimation(Cell cell)
    {
        cell.transform.localScale = Vector3.zero;
        cell.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);
    }
    
}