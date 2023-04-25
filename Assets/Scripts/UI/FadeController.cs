using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class FadeController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [Space]
        [Header("Animation settings")] 
        [SerializeField]
        private float _duration = 1f;

        public void FadeIn()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.DOFade(1, _duration);
            _canvasGroup.blocksRaycasts = true;
        }

        public void FadeOut()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.DOFade(0, _duration);
            _canvasGroup.blocksRaycasts = false;
        }
    }
}