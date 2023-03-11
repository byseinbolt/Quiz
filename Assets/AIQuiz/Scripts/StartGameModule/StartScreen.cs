using AIQuiz.Scripts.Events;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace AIQuiz.Scripts.StartGameModule
{
    public class StartScreen : BaseScreen
    {
        [SerializeField]
        private InputField _inputField;

        [SerializeField]
        private Button _sendRequestButton;

        private void Awake()
        {
            _sendRequestButton.onClick.AddListener(Click);
        }

        private void Click()
        {
            EventStreams.AIQuiz.Publish(new SendUserRequestEvent(_inputField.text));
        }
    }
}