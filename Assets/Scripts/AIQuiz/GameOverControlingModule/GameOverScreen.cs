using System;
using DG.Tweening;
using Events;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace AIQuiz
{
    public class GameOverScreen : BaseScreen
    {
        [SerializeField]
        private StartScreen _startScreen;
        
        [SerializeField]
        private Button _restartButton;

        [SerializeField]
        private Image _winImage;

        private IDisposable _subscription;
        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _subscription = EventStreams.AIQuiz.Subscribe<LevelPassedEvent>(OnLevelPassed);
        }

        protected override void SetUIActive(bool flag)
        {
            _restartButton.gameObject.SetActive(flag);
        }

        private void RestartGame()
        {
            Hide();
            _startScreen.Show();
        }

        private void OnLevelPassed(LevelPassedEvent eventData)
        {
            Show();
            _winImage.sprite = eventData.View;
            ShowWinImage();
        }

        private void ShowWinImage()
        {
            _winImage.rectTransform.localScale = Vector3.zero;
            _winImage.rectTransform.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBounce);
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}