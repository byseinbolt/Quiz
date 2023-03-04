using System;
using Events;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameScreen : BaseScreen
    {
        [SerializeField]
        private TextMeshProUGUI _goalLabel;

        private IDisposable _subscription;

        private void Awake()
        {
            _subscription = EventStreams.Game.Subscribe<GoalSelectedEvent>(SetGoal);
        }
        
        private void SetGoal(GoalSelectedEvent eventData)
        {
            _goalLabel.text = $"Find {eventData.Goal}";
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }

}