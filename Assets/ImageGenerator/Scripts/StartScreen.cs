using UI;
using UnityEngine;
using UnityEngine.UI;

namespace ImageGenerator
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
            EventStreams.Game.Publish(new SendUserRequestEvent(_inputField.text));
        }
    }
}