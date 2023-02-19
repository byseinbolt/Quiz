using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelCompletedScreenView : MonoBehaviour
    {
        [SerializeField]
        private Image _winImage;
        
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private RectTransform _restartButton;

        [SerializeField]
        private RectTransform _nextLevelButton;

        [SerializeField]
        private RectTransform _finalCongratulationsPanel;
        
        [SerializeField]
        private RectTransform _betweenLevelsCongratulationsPanels;
        
        
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        [UsedImplicitly]
        public void ShowWinImage(Cell cell)
        {
            _winImage.rectTransform.localScale = Vector3.zero;
            _winImage.sprite = cell.Image.sprite;
            _winImage.rectTransform.DOScale(Vector3.one, 2f).SetEase(Ease.OutBounce);
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
        

        public void ScreenFadeIn()
        {
            _canvasGroup.alpha = 0;
            _rectTransform.transform.localPosition = new Vector3(1350, 0f, 0f);
            _rectTransform.DOAnchorPos(new Vector2(960, 540), 1f);
            _canvasGroup.DOFade(1, 1);
        }

        public void ScreenFadeOut()
        {
            _canvasGroup.alpha = 1;
            _rectTransform.transform.localPosition = new Vector3(0,0,0);
            _rectTransform.DOAnchorPos(new Vector2(2880, 540), 1f);
            _canvasGroup.DOFade(0, 1);
        }

        private void PlayOutBounceAnimation(params RectTransform[] rectTransforms)
        {
            foreach (var rectTransform in rectTransforms)
            {
                rectTransform.localScale = Vector3.zero;
                rectTransform.DOScale(Vector3.one, 2f).SetEase(Ease.OutBounce);
            }
        }
    }
}