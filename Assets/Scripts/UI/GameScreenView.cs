using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameScreenView : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _goalLabel;
        
        [SerializeField] 
        private CanvasGroup _canvasGroup;
        
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
        
       [UsedImplicitly]
       // from UnityEvent in LevelController
       public void SetGoal(string goalItemName)
        {
            _goalLabel.text = $"Find {goalItemName}";
        }

        public void ScreenFadeIn()
        {
            _canvasGroup.alpha = 0;
            _rectTransform.transform.localPosition = new Vector3(0, -1500f, 0f);
            _rectTransform.DOAnchorPos(new Vector2(960, 540), 1f);
            _canvasGroup.DOFade(1, 1);
        }

        public void ScreenFadeOut()
        {
            _canvasGroup.alpha = 1;
            _rectTransform.transform.localPosition = new Vector3(0,0,0);
            _rectTransform.DOAnchorPos(new Vector2(960, -540), 1f);
            _canvasGroup.DOFade(0, 1);
        }
    }
}