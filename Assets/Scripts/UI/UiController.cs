using GameData;
using UnityEngine;

namespace UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField]
        private StartScreenController _startScreenController;

        // [SerializeField]
        // private LevelCompletedScreenView _levelCompletedScreenView;

        public void Initialize(DataProvider dataProvider)
        {
            _startScreenController.Initialize(dataProvider.GameSetData);
            // LevelCompletedScreenView.Initialize(winCell);
        }
    }
}