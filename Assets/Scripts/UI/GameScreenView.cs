﻿using DG.Tweening;
using GameData;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameScreenView : MonoBehaviour,IScreen
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
        // когда спавн закончился (через UnityEvent)
        public void SetGoal(string goalItemName)
        {
            _goalLabel.text = $"Find {goalItemName}";
        }

        public void ScreenFadeIn()
        {
            _canvasGroup.alpha = 0;
            _rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
            _rectTransform.DOAnchorPos(new Vector2(0, 0), 2f);
            _canvasGroup.DOFade(1, 2f);
        }

        public void ScreenFadeOut()
        {
            _canvasGroup.alpha = 1;
            _rectTransform.transform.localPosition = Vector3.zero;
            _rectTransform.DOAnchorPos(new Vector2(0, -1000), 2f);
            _canvasGroup.DOFade(0, 2f);
        }
    }
}