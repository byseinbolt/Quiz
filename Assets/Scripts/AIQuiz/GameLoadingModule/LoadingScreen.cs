using System;
using System.Collections.Generic;
using Events;
using TMPro;
using UI;
using UnityEngine;

namespace AIQuiz
{
    public class LoadingScreen : BaseScreen
    {
        [SerializeField]
        private ImageGenerator _imageGenerator;

        [SerializeField]
        private TextMeshProUGUI _loadingLabel;

        private IDisposable _subscription;
        
        private void Awake()
        {
            _imageGenerator.ImagesLoaded += OnImagesLoaded;
            _subscription = EventStreams.AIQuiz.Subscribe<SendUserRequestEvent>(ShowLoadingLabel);
        }

        protected override void SetUIActive(bool flag)
        {
            _loadingLabel.gameObject.SetActive(flag);
        }

        private void ShowLoadingLabel(SendUserRequestEvent eventData)
        {
            Show();
            _loadingLabel.text = $"Processing your {eventData.UserInput} request...";
        }

        private void OnImagesLoaded(Dictionary<string, Sprite> items)
        {
            EventStreams.AIQuiz.Publish(new LoadingCompletedEvent(items));
            Hide();
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}