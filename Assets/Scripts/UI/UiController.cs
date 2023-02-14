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

        private void Awake()
        {
            _startScreenView.Initialize(_gameSetsData);
        }
    }
}