using System.Collections.Generic;
using Events;
using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartScreen : BaseScreen
    {
        public Button ExitButton => _exitButton;
        
        [SerializeField] 
        private GameSetView _gameSetViewPrefab;
    
        [SerializeField]
        private Transform _iconsParent;

        [SerializeField]
        private Button _exitButton;

        public void Initialize(IEnumerable<GameSetData> gameSetsData)
        {
            foreach (var gameSetData in gameSetsData)
            {
                var gameSetViewInstance = Instantiate(_gameSetViewPrefab, _iconsParent);
                gameSetViewInstance.SetClickCallback(value => 
                    EventStreams.Game.Publish(new GameSetInstanceClickedEvent(value)));
                gameSetViewInstance.Initialize(gameSetData);
            }
        }
    }
}
