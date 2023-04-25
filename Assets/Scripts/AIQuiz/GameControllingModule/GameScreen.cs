using System;
using AIQuiz.Events;
using DG.Tweening;
using Events;
using TMPro;
using UI;
using UnityEngine;

namespace AIQuiz.GameControllingModule
{
    public class GameScreen : BaseScreen
    {
        public event Action HideItemsRequest;
        
        [SerializeField]
        private TextMeshProUGUI _goalLabel;
        
        public void SetGoal(string goal)
        {
            _goalLabel.text = $"Find {goal}";
        }

        public void OnGoalItemClicked(DallEItem item)
        {
            var rectTransform = item.Image.rectTransform;
            var sequence = DOTween.Sequence();
            sequence.AppendCallback(() => item.Button.interactable = false)
                .Append(rectTransform.DOScale(Vector3.zero, 1.5f).SetEase(Ease.InBounce))
                .AppendCallback(() => HideItemsRequest?.Invoke())
                .AppendCallback(() => EventStreams.AIQuiz.Publish(new LevelPassedEvent(item.Image.sprite)))
                .AppendCallback(Hide)
                .Append(rectTransform.DOScale(Vector3.one, 0.1f))
                .AppendCallback(() => item.Button.interactable = true);
        }

        public void OnWrongItemClicked(DallEItem item)
        {
            var sequence = DOTween.Sequence();
            sequence.AppendCallback(() => item.Button.interactable = false)
                .Append(item.Image.rectTransform.DORotate(new Vector3(0, 60, 0), 0.5f)
                    .SetEase(Ease.InBounce)
                    .SetLoops(2, LoopType.Yoyo))
                .AppendCallback(() => item.Button.interactable = true);
        }
    }
}