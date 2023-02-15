using System;
using GameData;
using UnityEngine;
using UnityEngine.Android;

namespace UI
{
    public class UiController : MonoBehaviour
    {
        // TODO: подумать должен ли UiController знать про GameSetData или про DataProvider
        [SerializeField]
        private GameSetData[] _gameSetsData;
        [SerializeField]
        private StartScreenView _startScreenView;

        public void Initialize()
        {
            _startScreenView.Initialize(_gameSetsData);
        }
    }
}