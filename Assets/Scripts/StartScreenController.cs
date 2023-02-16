using System;
using System.Collections.Generic;
using GameData;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class StartScreenController : MonoBehaviour
{
    //подумать над названием ивента
    [SerializeField]
    private UnityEvent<GameSetView> _onSetClicked;
        
    [SerializeField] 
    private GameSetView _gameSetViewPrefab;
    
    [SerializeField]
    private Transform _iconSpawnPosition;
    
    public void Initialize(IEnumerable<GameSetData> gameSetsData)
    {
        foreach (var gameSetData in gameSetsData)
        {
            var gameSetViewInstance = Instantiate(_gameSetViewPrefab, _iconSpawnPosition);
            gameSetViewInstance.SetClickCallback(value => _onSetClicked.Invoke(value));
            gameSetViewInstance.Initialize(gameSetData);
        }
    }
}
