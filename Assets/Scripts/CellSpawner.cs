using System;
using System.Collections.Generic;
using GameData;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

// TODO: прокидывать инф-ию про каждый уровень, подумать над названием класса
public class CellSpawner : MonoBehaviour
{
    public event Action<Cell> OnClicked;

    public IReadOnlyList<GameItem> OneLevelUsedGameItems => _oneLevelUsedGameItems;

    [SerializeField]
    private Transform _cellsSpawnPosition;
    
    [SerializeField]
    private Cell _cellPrefab;

    private readonly HashSet<GameItem> _allUsedGameItems = new();
    private List<GameItem> _oneLevelUsedGameItems;
    
    public void Spawn(IReadOnlyList<GameItem> selectedGameSetItems)
    {
        _oneLevelUsedGameItems = new List<GameItem>();
        
        for (var i = 0; i < 3; i++)
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
            cell.SetClickCallback(value => OnClicked?.Invoke(value));
            cell.Initialize(randomGameItem.ItemView);
            
        }
    }
}