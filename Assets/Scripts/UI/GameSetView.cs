using System;
using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameSetView : MonoBehaviour
    {
        public string GameSetName { get; private set; }
        public GameSetData GameSetData { get; private set; }
        
        [SerializeField]
        private Image _icon;
        
        private Action<GameSetView> _onClicked;
        

        public void Initialize(GameSetData gameSetData)
        {
            GameSetData = gameSetData;
            _icon.sprite = GameSetData.GameSetView;
            GameSetName = GameSetData.GameSetName;
        }
        
        public void Click()
        {
            _onClicked?.Invoke(this);
        }
        
        public void SetClickCallback(Action<GameSetView> onClicked)
        {
            _onClicked = onClicked;
        }
    }
}