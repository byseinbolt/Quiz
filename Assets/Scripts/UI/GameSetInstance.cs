using System;
using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    // TODO: решить относится этот класс к UI или нет
    public class GameSetInstance : MonoBehaviour
    {
        public GameSetData GameSetData { get; private set; }

        [SerializeField]
        private Image _icon;
        
        private Action<GameSetInstance> _onClicked;
        

        public void Initialize(GameSetData gameSetData)
        {
            _icon.sprite = gameSetData.GameSetView;
            GameSetData = gameSetData;
        }
        
        public void Click()
        {
            _onClicked?.Invoke(this);
            
        }
        
        public void SetClickCallback(Action<GameSetInstance> onClicked)
        {
            _onClicked = onClicked;
        }
        
       
    }
}