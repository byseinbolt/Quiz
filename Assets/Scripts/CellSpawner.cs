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
    
    private GameSetData _gameSetData;
    private HashSet<GameItem> _allUsedElements = new();
    private List<GameItem> _oneLevelUsedElements;

    public void Initialize(GameSetData selectedGameSet)
    {
        _gameSetData = selectedGameSet;
    }
    public void Spawn()
    {
        _oneLevelUsedElements = new List<GameItem>();
        
        for (var i = 0; i < 3; i++)
        {
            var randomElementIndex = Random.Range(0, _gameSetData.GameItems.Length);
            var randomGameItem = _gameSetData.GameItems[randomElementIndex];
            
            if (_allUsedElements.Contains(randomGameItem))
            {
                i--;
                continue;
            }
            
            _allUsedElements.Add(randomGameItem);
            _oneLevelUsedElements.Add(randomGameItem);
            
            var cell = Instantiate(_cellPrefab, _cellsSpawnPosition);
            //cell.SetClickCallback(value =>OnClicked.Invoke(value));
            cell.Image.sprite = randomGameItem.ItemView;
        }
        _spawnCompleted.Invoke();
    }
    
    public GameItem GetGoal()
    {
        var randomUsedGameItemIndex = Random.Range(0, _oneLevelUsedElements.Count);
        return _gameSetData.GameItems[randomUsedGameItemIndex];
    }
}