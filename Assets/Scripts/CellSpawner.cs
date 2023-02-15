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
    
    // добавил хэшсет так как теперь мы храним там один цельный объект GameItem
    private readonly HashSet<GameItem> _allUsedGameItems = new();
    
    // здесь тоже изменил int на GameItem
    private List<GameItem> _oneLevelUsedGameItems;
    
    private GameSetData _gameSetData;

    public void Initialize(GameSetData selectedGameSet)
    {
        _gameSetData = selectedGameSet;

        // сделал спавн приватным и ызываю его здесь
        Spawn();
    }
    
    private void Spawn()
    {
        _oneLevelUsedGameItems = new List<GameItem>();
        
        for (var i = 0; i < 3; i++)
        {
            var randomElementIndex = Random.Range(0, _gameSetData.GameItems.Count);
            
            // теперь мы вытаскиваем цельный рандомный объект 
            var randomGameItem = _gameSetData.GameItems[randomElementIndex];
            
            if (_allUsedGameItems.Contains(randomGameItem))
            {
                i--;
                continue;
            }
            
            // добавляем тоже теперь цельный объект
            _allUsedGameItems.Add(randomGameItem);
            _oneLevelUsedGameItems.Add(randomGameItem);
            
            var cell = Instantiate(_cellPrefab, _cellsSpawnPosition);
            //cell.SetClickCallback(value =>OnClicked.Invoke(value));
            
            // картинку уже вытаскиваем из рандомного объекта
            cell.Image.sprite = randomGameItem.ItemView;
        }
        _spawnCompleted.Invoke();
    }
    
    // теперь метод возвращает нам объект GameItem и из него в GameScreenView через CellSpawner вытаскиваем имя и сеттим в наш текст "Find {}"
    public GameItem GetGoal()
    {
        var randomUsedGameItemIndex = Random.Range(0, _oneLevelUsedGameItems.Count);
        return _oneLevelUsedGameItems[randomUsedGameItemIndex];
    }
}