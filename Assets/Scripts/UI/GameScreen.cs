using DG.Tweening;
using Events;
using SimpleEventBus.Disposables;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameScreen : BaseScreen
    {
        [Header("References")]
        [SerializeField]
        private TextMeshProUGUI _goalLabel;

        [Space]
        [Header("Animation settings")]
        [SerializeField]
        private float _disappearDuration;
        
        [SerializeField, Range(0.1f, 0.3f)]
        private float _upscaleDuration;

        [SerializeField]
        private float _waitingTimeBeforeHidingCells;
        
        [SerializeField] 
        private float _rotationDegreesY;

        [SerializeField]
        private float _rotationDuration;
        
        private CompositeDisposable _subscriptions;

        private void Awake()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<GoalSelectedEvent>(SetGoal),
                EventStreams.Game.Subscribe<WrongCellClickedEvent>(OnWrongCellClicked),
                EventStreams.Game.Subscribe<LevelCompletedEvent>(OnLevelCompleted)
            };
        }

        // TODO: разобраться как вызвать метод исчезновения ячеек
        private void OnLevelCompleted(LevelCompletedEvent eventData)
        {
            var sequence = DOTween.Sequence();

            sequence.AppendCallback(() => eventData.Cell.Button.interactable = false)
                .Append(eventData.Cell.Image.rectTransform.DOScale(Vector3.zero, _disappearDuration).SetEase(Ease.InBounce))
                .AppendCallback(() => EventStreams.Game.Publish(new WinAnimationCompletedEvent(eventData.Cell)))
                .AppendInterval(_waitingTimeBeforeHidingCells)
                .AppendCallback(() => EventStreams.Game.Publish(new HideCellsRequest()))
                .Append(eventData.Cell.Image.rectTransform.DOScale(Vector3.one, _upscaleDuration))
                     .AppendCallback(() => eventData.Cell.Button.interactable = true);

        }

        private void SetGoal(GoalSelectedEvent eventData)
        {
            _goalLabel.text = $"Find {eventData.Goal}";
        }
        
        private void OnWrongCellClicked(WrongCellClickedEvent eventData)
        {
            var sequence = DOTween.Sequence();
            
            sequence.AppendCallback(() => eventData.Button.interactable = false)
                .Append(eventData.Cell.Image.rectTransform.DORotate(new Vector3(0, _rotationDegreesY, 0), _rotationDuration)
                    .SetEase(Ease.InBounce)
                    .SetLoops(2, LoopType.Yoyo))
                .AppendCallback(() => eventData.Button.interactable = true);
        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }
    }

}