using System;
using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class GameOverScreenView : MonoBehaviour, IScreen
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
            _rectTransform.transform.localPosition = new Vector3(960, -1000f, 0f);
            _rectTransform.DOAnchorPos(new Vector2(960, 540), 2f);
            _canvasGroup.DOFade(1, 1);
        }

        public void ScreenFadeOut()
        {
            _canvasGroup.alpha = 1;
            _rectTransform.transform.localPosition = new Vector3(960,540,0);
            _rectTransform.DOAnchorPos(new Vector2(960, -1000), 2f);
            _canvasGroup.DOFade(0, 1);
        }
    }
}