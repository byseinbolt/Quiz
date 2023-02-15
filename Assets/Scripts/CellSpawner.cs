using System;
using System.Collections.Generic;
using GameData;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CellSpawner : MonoBehaviour
{
    public Action<Cell> OnClicked;
    
    [SerializeField]
    private Transform _cellsSpawnPosition;
    [SerializeField]
    private Cell _cellPrefab;
    
    [SerializeField]
    private UnityEvent _spawnCompleted;
    
    private readonly HashSet<GameItem> _allUsedGameItems = new();
    private List<GameItem> _oneLevelUsedGameItems;
    private GameSetData _gameSetData;

    public void Initialize(GameSetData selectedGameSet)
    {
        _gameSetData = selectedGameSet;
        Spawn();
    }
    
    private void Spawn()
    {
        _oneLevelUsedGameItems = new List<GameItem>();
        
        for (var i = 0; i < 3; i++)
        {
            var randomElementIndex = Random.Range(0, _gameSetData.GameItems.Count);
            var randomGameItem = _gameSetData.GameItems[randomElementIndex];
            
            if (_allUsedGameItems.Contains(randomGameItem))
            {
                i--;
                continue;
            }
            _allUsedGameItems.Add(randomGameItem);
            _oneLevelUsedGameItems.Add(randomGameItem);
            
            var cell = Instantiate(_cellPrefab, _cellsSpawnPosition);
            cell.Initialize(randomGameItem.ItemView);
        }
        _spawnCompleted.Invoke();
    }
    
    public GameItem GetGoal()
    {
        var randomUsedGameItemIndex = Random.Range(0, _oneLevelUsedGameItems.Count);
        return _oneLevelUsedGameItems[randomUsedGameItemIndex];
    }
}