using System;
using System.Collections.Generic;
using AIQuiz.Events;
using Events;
using TMPro;
using UI;
using UnityEngine;

namespace AIQuiz.GameLoadingModule
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
        
        private void ShowLoadingLabel(SendUserRequestEvent eventData)
        {
            Show();
            _loadingLabel.text = $"Processing your {eventData.Topic} request...";
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