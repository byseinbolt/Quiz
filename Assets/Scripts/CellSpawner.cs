using System;
using System.Collections.Generic;
using DG.Tweening;
using GameData;
using UnityEngine;
using UnityEngine.Pool;

public class CellSpawner : MonoBehaviour
{
    public event Action<Cell> OnClicked;
    
    [SerializeField]
    private RectTransform _cellsSpawnParent;
    
    [SerializeField]
    private Cell _cellPrefab;
    
    private ObjectPool<Cell> _pool;
    private List<Cell> _cells;

    private void Start()
    {
        _pool = new ObjectPool<Cell>(() => Instantiate(_cellPrefab, _cellsSpawnParent));
    }
    
    public void Spawn(IReadOnlyList<GameItem> selectedGameSetItems)
    {
        _cells = ListPool<Cell>.Get();
        foreach (var gameItem in selectedGameSetItems)
        {
            var cell = CreateCell();
            
            cell.SetClickCallback(value => OnClicked?.Invoke(value));
            cell.Initialize(gameItem.View);
            _cells.Add(cell);
        }
        PlayAnimation(_cells);
    }

    public void HidePreviousLevelCells()
    {
        foreach (var cell in _cells)
        {
            cell.gameObject.SetActive(false);
            _pool.Release(cell);
        }
    }

    private Cell CreateCell()
    {
        var cell = _pool.Get();
        cell.gameObject.SetActive(true);
        return cell;
    }
    
    
   private void PlayAnimation(List<Cell> cells)
   {
       foreach (var cell in cells)
       {
           cell.transform.localScale = Vector3.zero;
           cell.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);
       }
   }
}