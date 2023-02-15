using System;
using GameData;
using UnityEngine;

namespace UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField]
        private GameSetData[] _gameSetsData;
        [SerializeField]
        private StartScreenView _startScreenView;
        [SerializeField]
        private ScreenChanger _screenChanger;

        public void Initialize()
        {
            _startScreenView.Initialize(_gameSetsData);
            //_startScreenView.OnSetInstanceClicked += _screenChanger.ShowGameScreen;
        }

        private void OnDestroy()
        {
           // _startScreenView.OnSetInstanceClicked -= _screenChanger.ShowGameScreen;
        }
    }
}