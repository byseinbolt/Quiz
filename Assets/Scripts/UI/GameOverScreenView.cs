using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class GameOverScreenView : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void ScreenFadeIn()
        {
            _canvasGroup.alpha = 0;
            _rectTransform.transform.localPosition = new Vector3(-1350, 0f, 0f);
            _rectTransform.DOAnchorPos(new Vector2(960, 540), 2f);
            _canvasGroup.DOFade(1, 1);
        }
        
        public void ScreenFadeOut()
        {
            _canvasGroup.alpha = 1;
            _rectTransform.transform.localPosition = new Vector3(0,0,0);
            _rectTransform.DOAnchorPos(new Vector2(-960, 540), 2f);
            _canvasGroup.DOFade(0, 1);
        }
    }
}