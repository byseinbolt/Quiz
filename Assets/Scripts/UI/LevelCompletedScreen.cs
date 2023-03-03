using System;
using DG.Tweening;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelCompletedScreen : BaseScreen
    {
        [SerializeField]
        private Image _winImage;
        
        [SerializeField]
        private RectTransform _restartButton;

        [SerializeField]
        private RectTransform _nextLevelButton;

        [SerializeField]
        private RectTransform _finalCongratulationsPanel;
        
        [SerializeField]
        private RectTransform _betweenLevelsCongratulationsPanels;

        [SerializeField]
        private float _durationBounceAnimation = 2f;

        [SerializeField] 
        private float _durationWinImageAnimation = 2f;

        private IDisposable _subscription;

        private void Awake()
        {
            _subscription = EventStreams.Game.Subscribe<LevelCompletedEvent>(OnLevelCompleted);
        }

        private void OnLevelCompleted(LevelCompletedEvent eventData)
        {
            _winImage.rectTransform.localScale = Vector3.zero;
            _winImage.sprite = eventData.Cell.Image.sprite;
            _winImage.rectTransform.DOScale(Vector3.one, _durationWinImageAnimation).SetEase(Ease.OutBounce);
        }

        
        public void ShowRestartView()
        {
            _nextLevelButton.localScale = Vector3.zero;
            _betweenLevelsCongratulationsPanels.localScale = Vector3.zero;
            PlayOutBounceAnimation(_finalCongratulationsPanel,_restartButton);
        }

        public void ShowNextLevelButton()
        {
            _finalCongratulationsPanel.localScale = Vector3.zero;
            _restartButton.localScale = Vector3.zero;
           PlayOutBounceAnimation(_nextLevelButton, _betweenLevelsCongratulationsPanels);
        }

        private void PlayOutBounceAnimation(params RectTransform[] rectTransforms)
        {
            foreach (var rectTransform in rectTransforms)
            {
                rectTransform.localScale = Vector3.zero;
                rectTransform.DOScale(Vector3.one, _durationBounceAnimation).SetEase(Ease.OutBounce);
            }
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}