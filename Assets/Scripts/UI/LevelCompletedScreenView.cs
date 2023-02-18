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
        
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        [UsedImplicitly]
        public void ShowWinImage(Cell cell)
        {
            _winImage.sprite = cell.Image.sprite;
        }

        public void ScreenFadeIn()
        {
            _canvasGroup.alpha = 0;
            _rectTransform.transform.localPosition = new Vector3(1350, 0f, 0f);
            _rectTransform.DOAnchorPos(new Vector2(960, 540), 2f);
            _canvasGroup.DOFade(1, 1);
        }

        public void ScreenFadeOut()
        {
            _canvasGroup.alpha = 1;
            _rectTransform.transform.localPosition = new Vector3(0,0,0);
            _rectTransform.DOAnchorPos(new Vector2(2880, 540), 2f);
            _canvasGroup.DOFade(0, 1);
        }
    }
}