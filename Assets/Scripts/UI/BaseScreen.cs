using UnityEngine;

namespace UI
{
    public class BaseScreen : MonoBehaviour
    {
        [SerializeField]
        private FadeController _fadeController;

        public void Show()
        {
            _fadeController.FadeIn();
            SetUIActive(true);
        }

        public void Hide()
        {
            _fadeController.FadeOut();
            SetUIActive(false);
        }

        protected virtual void SetUIActive(bool flag)
        {
        }
    }
}