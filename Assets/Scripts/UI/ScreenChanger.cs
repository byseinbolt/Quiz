using JetBrains.Annotations;
using UnityEngine;

namespace UI
{
    public class ScreenChanger : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameScreen;
        [SerializeField]
        private StartScreenView _startScreen;
        
        // TODO: заменить включение и выключение объектов на CanvasGroup FadeIn/FadeOut
        public void ShowGameScreen()
        {
            _startScreen.gameObject.SetActive(false);
            _gameScreen.SetActive(true);
        }
    }
}