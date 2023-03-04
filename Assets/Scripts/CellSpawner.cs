﻿using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Events;
using GameData;
using Pools;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    [SerializeField]
    private RectTransform _cellsSpawnParent;
    
    [SerializeField]
    private Cell _cellPrefab;
    
    private MonoBehaviourPool<Cell> _pool;
    
    private void Start()
    {
        _pool = new MonoBehaviourPool<Cell>(_cellPrefab, _cellsSpawnParent);
    }
    
    public void Spawn(IReadOnlyList<GameItem> selectedGameSetItems)
    {
        foreach (var gameItem in selectedGameSetItems)
        {
            var cell = _pool.Take();
            cell.SetClickCallback(value => EventStreams.Game.Publish(new CellClickedEvent(value)));
            cell.Initialize(gameItem.View);
        }
        PlayAnimation(_pool.UsedItems.ToList());
    }

    public void HidePreviousLevelCells()
    {
       _pool.ReleaseAll();
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