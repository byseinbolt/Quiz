using UnityEngine;

namespace UI
{
    public class ScreenChanger : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameScreen;
        
        [SerializeField]
        private StartScreenView _startScreen;

        [SerializeField]
        private GameObject _levelCompletedScreen;
        
        [SerializeField]
        private GameObject _gameOverScreen;
        
        // TODO: заменить включение и выключение объектов на CanvasGroup FadeIn/FadeOut
        public void ShowGameScreen()
        {
            _startScreen.gameObject.SetActive(false);
            _levelCompletedScreen.SetActive(false);
            _gameOverScreen.SetActive(false);
            _gameScreen.SetActive(true);
        }
        public void ShowLevelCompletedScreen()
        {
            _gameScreen.SetActive(false);
            _startScreen.gameObject.SetActive(false);
            _gameOverScreen.SetActive(false);
            _levelCompletedScreen.SetActive(true);
        }

        public void ShowStartScreen()
        {
            _gameOverScreen.SetActive(false);
            _gameScreen.SetActive(false);
            _levelCompletedScreen.SetActive(false);
            _startScreen.gameObject.SetActive(true);
        }

        public void ShowGameOverScreen()
        {
            _startScreen.gameObject.SetActive(false);
            _gameScreen.SetActive(false);
            _levelCompletedScreen.SetActive(false);
            _gameOverScreen.SetActive(true);
        }
    }
}