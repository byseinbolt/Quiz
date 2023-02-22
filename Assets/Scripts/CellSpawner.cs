using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using GameData;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    public event Action<Cell> OnClicked;
    
    [SerializeField]
    private RectTransform _cellsSpawnParent;
    
    [SerializeField]
    private Cell _cellPrefab;

    [SerializeField]
    private ObjectPool _objectPool;
    
    private List<Cell> _cells = new();

    private void Start()
    {
        _objectPool.CreateObjectPool(_cellPrefab, _cellsSpawnParent);
    }

    // TODO: довести пул до ума
    public void Spawn(IReadOnlyList<GameItem> selectedGameSetItems)
    {
        _objectPool.ReleaseAll(ref _cells);
       
        foreach (var item in selectedGameSetItems)
        {
            var cell = _objectPool.GetObject();
            cell.SetClickCallback(value => OnClicked?.Invoke(value));
            cell.Initialize(item.ItemView);
            _cells.Add(cell);
        }
        
        //PlayAnimation(_cells);
    }
    
    
    private void PlayAnimation(List<Cell> cells)
    {
        var sequence = DOTween.Sequence();
        foreach (var cell in cells)
        {
            cell.transform.localScale = Vector3.zero;
            sequence.Append(cell.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce));
        }
    }
}