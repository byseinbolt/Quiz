using AIQuiz.Events;
using Events;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AIQuiz.GameStartingModule
{
    public class StartScreen : BaseScreen
    {
        [SerializeField]
        private TMP_InputField _inputField;

        [SerializeField] 
        private Button _sendButton;

        [SerializeField]
        private Button _exitButton;
        
        private void Awake()
        {
            Show();
            _sendButton.onClick.AddListener(Click);
            _exitButton.onClick.AddListener(LoadStartScene);
        }

        private void LoadStartScene()
        {
            SceneManager.LoadSceneAsync(SceneNames.START_SCENE);
        }

        private void Click()
        {
            EventStreams.AIQuiz.Publish(new SendUserRequestEvent(_inputField.text));
            Hide();
        }
    }
}