﻿using System.Collections.Generic;
using DG.Tweening;
using GameData;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class StartScreenView : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent<GameSetView> _onGameSetClicked;
        
        [SerializeField] 
        private GameSetView _gameSetViewPrefab;
    
        [SerializeField]
        private Transform _iconSpawnPosition;
        
        [SerializeField]
        private CanvasGroup _canvasGroup;
        
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
    
        public void Initialize(IEnumerable<GameSetData> gameSetsData)
        {
            foreach (var gameSetData in gameSetsData)
            {
                var gameSetViewInstance = Instantiate(_gameSetViewPrefab, _iconSpawnPosition);
                gameSetViewInstance.SetClickCallback(value => _onGameSetClicked.Invoke(value));
                gameSetViewInstance.Initialize(gameSetData);
            }
        }

        public void ScreenFadeIn()
        {
            _canvasGroup.alpha = 0;
            _rectTransform.transform.localPosition = new Vector3(0, 1300, 0f);
            _rectTransform.DOAnchorPos(new Vector2(960, 540), 1f);
            _canvasGroup.DOFade(1, 1);
        }

        public void ScreenFadeOut()
        {
            _canvasGroup.alpha = 1;
            _rectTransform.transform.localPosition = new Vector3(0,-0,0);
            _rectTransform.DOAnchorPos(new Vector2(960, 1620), 1f);
            _canvasGroup.DOFade(0, 1);
        }
    }
}
