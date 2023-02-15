using System;
using GameData;
using Unity.VisualScripting;
using UnityEngine;
using UI;

namespace UI
{
    public class StartScreenView : MonoBehaviour
    {
        public event Action<GameSetInstance> OnInstanceClicked;
        public event Action OnSetInstanceClicked;
        
        
        [SerializeField]
        private GameSetInstance _gameSetsPrefab;
        
        [SerializeField]
        private Transform _iconSpawnPosition;
        
        public void Initialize(GameSetData[] gameSetsData)
        {
            for (var i = 0; i < gameSetsData.Length; i++)
            {
                var gameSetIconInstance = Instantiate(_gameSetsPrefab, _iconSpawnPosition);
                gameSetIconInstance.SetClickCallback(value =>OnInstanceClicked?.Invoke(value));
                gameSetIconInstance.SetClickCallback(value =>OnSetInstanceClicked?.Invoke());
                gameSetIconInstance.Initialize(gameSetsData[i]);
            }
        }
    }
}