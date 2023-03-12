using System;
using Events;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace AIQuiz
{
    public class StartScreen : BaseScreen
    {
        [SerializeField]
        private TMP_InputField _inputField;

        [SerializeField] 
        private Button _sendButton;

        [SerializeField]
        private TextMeshProUGUI _gameNameLabel;

        [SerializeField]
        private TextMeshProUGUI _instructionsLabel;
        
        
        private void Awake()
        {
            Show();
            _sendButton.onClick.AddListener(Click);
        }
        
        private void Click()
        {
            EventStreams.AIQuiz.Publish(new SendUserRequestEvent(_inputField.text));
            Hide();
        }

        protected override void SetUIActive(bool flag)
        {
            _gameNameLabel.gameObject.SetActive(flag);
            _instructionsLabel.gameObject.SetActive(flag);
            _inputField.gameObject.SetActive(flag);
            _sendButton.gameObject.SetActive(flag);
        }
    }
}