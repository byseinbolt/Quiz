﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    private Transform _cellsSpawnPosition;
    
    [SerializeField]
    private Cell _cellPrefab;

    private readonly HashSet<GameItem> _allUsedGameItems = new();
    private List<GameItem> _oneLevelUsedGameItems = new();
    private List<Cell> _cells = new();

    public void Spawn(IReadOnlyList<GameItem> selectedGameSetItems, LevelData currentLevel)
    {
        // TODO: вынести в отдельный метод
        if (_cells.Count!=0)
        {
            foreach (var cell in _cells.Where(cell => cell!=null))
            {
                Destroy(cell.gameObject);
            }
        }
        _oneLevelUsedGameItems = new List<GameItem>();
        
        for (var i = 0; i < currentLevel.LevelElementsCount; i++)
        {
            var randomElementIndex = Random.Range(0, selectedGameSetItems.Count);
            var randomGameItem = selectedGameSetItems[randomElementIndex];
            
            if (_allUsedGameItems.Contains(randomGameItem))
            {
                i--;
                continue;
            }
            _allUsedGameItems.Add(randomGameItem);
            _oneLevelUsedGameItems.Add(randomGameItem);
            
            var cell = Instantiate(_cellPrefab, _cellsSpawnPosition);
            _cells.Add(cell);
            cell.SetClickCallback(value => OnClicked?.Invoke(value));
            cell.Initialize(randomGameItem.ItemView);
        }
    }
    
    
}