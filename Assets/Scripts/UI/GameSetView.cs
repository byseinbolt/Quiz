using System;
using System.Collections.Generic;
using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameSetView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;
        
        private Action<GameSetView> _onClicked;
        private GameSetData _gameSetData;
        private string _gameSetName;
        
        public void Initialize(GameSetData gameSetData)
        {
            _gameSetData = gameSetData;
            _icon.sprite = _gameSetData.GameSetView;
            _gameSetName = _gameSetData.GameSetName;
        }
        
        public void Click()
        {
            _onClicked?.Invoke(this);
        }
        
        public void SetClickCallback(Action<GameSetView> onClicked)
        {
            _onClicked = onClicked;
        }

        public IReadOnlyList<GameItem> GetSetItems()
        {
            return _gameSetData.GameItems;
        }
    }
}