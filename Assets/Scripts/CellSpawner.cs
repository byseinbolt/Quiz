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
    private UnityEvent _spawnCompleted;
    
    [SerializeField]
    private Transform _cellsSpawnPosition;
    [SerializeField]
    private Cell _cell;
    
    
    // [SerializeField]
    // private GameSet _gameSet;

    private GameSetData _gameSetData;
    private Dictionary<string, Sprite> _allUsedElements = new();
    private List<int> _oneLevelUsedElements;

    public void Initialize(GameSetData selectedGameSet)
    {
        _gameSetData = selectedGameSet;
    }
    public void Spawn()
    {
        _oneLevelUsedElements = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            var randomElementIndex = Random.Range(0, _gameSetData.GameSet.GameItemViews.Length);
            var randomGameElementView = _gameSetData.GameSet.GameItemViews[randomElementIndex];
            var randomGameElementName = _gameSetData.GameSet.GameItemNames[randomElementIndex];

            if (_allUsedElements.ContainsKey(randomGameElementName))
            {
                i--;
                continue;
            }
            _allUsedElements.Add(randomGameElementName, randomGameElementView);
            _oneLevelUsedElements.Add(randomElementIndex);
            
            var cell = Instantiate(_cell, _cellsSpawnPosition);
            //cell.SetClickCallback(value =>OnClicked.Invoke(value));
            cell.Image.sprite = randomGameElementView;
        }
        _spawnCompleted.Invoke();
    }
    
    public string GetGoal()
    {
        var randomUsedElement = Random.Range(0, _oneLevelUsedElements.Count);
        var randomGoalIndex = _oneLevelUsedElements[randomUsedElement];
        return _gameSetData.GameSet.GameItemNames[randomGoalIndex];
    }
}