using System;
using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameSet : MonoBehaviour
    {
        public string GameSetName { get; private set; }
        
        [SerializeField]
        private Image _icon;
        
        private Action<GameSet> _onClicked;
        
        public void Initialize(GameSetData gameSetData)
        {
            _icon.sprite = gameSetData.GameSetView;
            GameSetName = gameSetData.GameSetName;
        }
        
        public void Click()
        {
            _onClicked?.Invoke(this);
            
        }
        
        public void SetClickCallback(Action<GameSet> onClicked)
        {
            _onClicked = onClicked;
        }
    }
}