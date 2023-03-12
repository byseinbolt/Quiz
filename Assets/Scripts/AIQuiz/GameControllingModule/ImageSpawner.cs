using System;
using Events;
using Pools;
using UnityEngine;

namespace AIQuiz
{
    public class ImageSpawner : MonoBehaviour
    {
        public event Action<DallEItem> ImageClicked;
        public event Action SpawnCompleted;
            
        [SerializeField]
        private DallEItem _dallEItemPrefab;

        [SerializeField]
        private RectTransform _spawnRoot;

        private MonoBehaviourPool<DallEItem> _pool;
        private IDisposable _subscription;

        private void Awake()
        {
            _pool = new MonoBehaviourPool<DallEItem>(_dallEItemPrefab, _spawnRoot);
            _subscription = EventStreams.AIQuiz.Subscribe<LoadingCompletedEvent>(Spawn);
        }

        private void Spawn(LoadingCompletedEvent eventData)
        {
            foreach (var item in eventData.Items)
            {
                var dallEImage = _pool.Take();
                dallEImage.Initialize(item.Key, item.Value);
                dallEImage.SetClickCallBack(value => ImageClicked?.Invoke(value));
            }
            SpawnCompleted?.Invoke();
        }

        public void HidePreviousImages()
        {
           _pool.ReleaseAll();
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}