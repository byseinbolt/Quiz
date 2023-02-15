using System;
using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameSetIconInstance : MonoBehaviour
    {
        public GameSetData GameSetData { get; private set; }

        [SerializeField]
        private Image _icon;
        
        private Action<GameSetIconInstance> _onClicked;

        public void Initialize(GameSetData gameSetData)
        {
            _icon.sprite = gameSetData.GameSetView;
            GameSetData = gameSetData;
        }
        
        public void Click()
        {
            _onClicked?.Invoke(this);
        }
        
        public void SetClickCallback(Action<GameSetIconInstance> onClicked)
        {
            _onClicked = onClicked;
        }

    }
}