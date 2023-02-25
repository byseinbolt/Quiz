using DG.Tweening;
using JetBrains.Annotations;
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
        
        [UsedImplicitly]
        public void ShowWinImage(Cell cell)
        {
            _winImage.rectTransform.localScale = Vector3.zero;
            _winImage.sprite = cell.Image.sprite;
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
    }
}