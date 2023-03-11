using System;
using AIQuiz.Scripts.Events;
using UnityEngine;

namespace AIQuiz.Scripts
{
    public class ImageSpawner : MonoBehaviour
    {
        [SerializeField] private ImageInstance _imagePrefab;
        [SerializeField] private RectTransform _spawnRoot;

        private IDisposable _subscription;
        
        private void Awake()
        {
            _subscription = EventStreams.AIQuiz.Subscribe<ImageLoadedEvent>(OnImageLoaded);
        }

        private void OnImageLoaded(ImageLoadedEvent eventData)
        {
            var image = Instantiate(_imagePrefab, _spawnRoot);
            image.Initialize(eventData.Sprite);
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}