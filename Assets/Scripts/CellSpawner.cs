using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using GameData;
using UnityEngine;
using UnityEngine.Pool;

public class CellSpawner : MonoBehaviour
{
    public event Action<Cell> OnClicked;
    
    [SerializeField]
    private RectTransform _cellsSpawnPosition;
    
    [SerializeField]
    private Cell _cellPrefab;

    [SerializeField]
    private List<Cell> _cells;

    public void Spawn(IReadOnlyList<GameItem> selectedGameSetItems)
    {
        var cells = ListPool<Cell>.Get();
       // DestroyPreviousLevelCells();

        foreach (var item in selectedGameSetItems)
        {
            var cell = Instantiate(_cellPrefab, _cellsSpawnPosition);
            cell.SetClickCallback(value => OnClicked?.Invoke(value));
            cell.Initialize(item.ItemView);
           // _cells.Add(cell);
            cells.Add(cell);
        }
        PlayAnimation(cells);
    }

   //TODO : Изменить на пул
    private void DestroyPreviousLevelCells(List<Cell> cells)
    {
        if (_cells.Count == 0) return;
        foreach (var cell in cells)
        {
            cell.gameObject.SetActive(false);
        }
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