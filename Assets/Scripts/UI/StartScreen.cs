using System.Collections.Generic;
using GameData;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class StartScreen : BaseScreen
    {
        [SerializeField]
        private UnityEvent<GameSetView> _onGameSetClicked;
        
        [SerializeField] 
        private GameSetView _gameSetViewViewPrefab;
    
        [SerializeField]
        private Transform _iconSpawnPosition;

        public void Initialize(IEnumerable<GameSetData> gameSetsData)
        {
            foreach (var gameSetData in gameSetsData)
            {
                var gameSetViewInstance = Instantiate(_gameSetViewViewPrefab, _iconSpawnPosition);
                gameSetViewInstance.SetClickCallback(value => _onGameSetClicked.Invoke(value));
                gameSetViewInstance.Initialize(gameSetData);
            }
        }
    }
}
