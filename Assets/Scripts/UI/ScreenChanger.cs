using UnityEngine;

namespace UI
{
    public class ScreenChanger : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameScreen;
        
        [SerializeField]
        private StartScreenController _startScreen;

        [SerializeField]
        private GameObject _gameOverScreen;
        
        // TODO: заменить включение и выключение объектов на CanvasGroup FadeIn/FadeOut
        public void ShowGameScreen()
        {
            _startScreen.gameObject.SetActive(false);
            _gameScreen.SetActive(true);
        }
        public void ShowGameOverScreen()
        {
            _gameScreen.SetActive(false);
            _gameOverScreen.SetActive(true);
        }
    }
}