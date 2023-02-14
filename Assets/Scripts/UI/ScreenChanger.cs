using JetBrains.Annotations;
using UnityEngine;

namespace UI
{
    public class ScreenChanger : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameScreen;
        [SerializeField]
        private GameObject _startScreen;

        [UsedImplicitly]
        // при клике на набор
        public void ShowGameScreen()
        {
            _startScreen.SetActive(false);
            _gameScreen.SetActive(true);
        }
    }
}