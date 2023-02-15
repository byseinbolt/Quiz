using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "GameSetData",menuName = "GameSetData")]
    public class GameSetData : ScriptableObject
    {
        public Sprite GameSetView => _gameSetView;
        
        // добавил сюда IReadOnlyList, потому что у нвс есть ссылка в CellSpawner  на GameSetData
        // и из CellSpawner мы можем изменять содержимое наших GameItems. А используя IReadOnlyList 
        // мы запрещаем любое изменение вне класса наших айтемов.
        public IReadOnlyList<GameItem> GameItems => _gameItems;
        
        [SerializeField]
        private Sprite _gameSetView;
        [SerializeField]
        private List<GameItem> _gameItems;
    }
}
