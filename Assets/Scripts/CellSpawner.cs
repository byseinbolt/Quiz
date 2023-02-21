using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using GameData;
using UnityEngine;
using Random = UnityEngine.Random;

public class CellSpawner : MonoBehaviour
{
    public event Action<Cell> OnClicked;
    
    [SerializeField]
    private RectTransform _cellsSpawnPosition;
    
    [SerializeField]
    private Cell _cellPrefab;
    
    private List<Cell> _cells = new();
    
    public void Spawn(IReadOnlyList<GameItem> selectedGameSetItems)
    {
        DestroyPreviousLevelCells();

        foreach (var item in selectedGameSetItems)
        {
            var cell = Instantiate(_cellPrefab, _cellsSpawnPosition);
            cell.SetClickCallback(value => OnClicked?.Invoke(value));
            cell.Initialize(item.ItemView);
            _cells.Add(cell);

            PlayAnimation(cell);
            
        }
    }

    //TODO : Изменить на пул
    private void DestroyPreviousLevelCells()
    {
        if (_cells.Count == 0) return;
        
        foreach (var cell in _cells.Where(cell => cell != null))
        {
            Destroy(cell.gameObject);
        }
    }

    private void PlayAnimation(Cell cell)
    {
        var sequence = DOTween.Sequence();
        cell.transform.localScale = Vector3.zero;
        cell.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);
    }
}