using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace AIQuiz
{
    public class GoalSelector : MonoBehaviour
    {
        [SerializeField]
        private UserRequestSender _userRequestSender;

        public string Goal { get; private set; }

        private void Awake()
        {
            _userRequestSender.PromptsCollected += OnPromptsCollected;
        }

        private void OnPromptsCollected(IReadOnlyList<string> prompts)
        {
            Goal = prompts.GetRandomItem();
        }
    }
}