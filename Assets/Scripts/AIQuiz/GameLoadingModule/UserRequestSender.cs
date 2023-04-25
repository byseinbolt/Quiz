using System;
using System.Collections.Generic;
using AIQuiz.Events;
using Events;
using OpenAI;
using UnityEngine;

namespace AIQuiz.GameLoadingModule
{
    public class UserRequestSender : MonoBehaviour
    {
        public event Action<IReadOnlyList<string>> PromptsCollected;
        
        [SerializeField]
        private ImageGenerator _imageGenerator;
        
        [SerializeField]
        private int _elementsCount;
        
        private readonly OpenAIApi _openAI = new();
        private IDisposable _subscription;
        private IReadOnlyList<string> _prompts;

        private void Awake()
        {
            _subscription = EventStreams.AIQuiz.Subscribe<SendUserRequestEvent>(SendRequest);
        }
        
        private async void SendRequest(SendUserRequestEvent eventData)
        {
            var completionResponse = await _openAI.CreateCompletion(new CreateCompletionRequest
            {
                Prompt = $"Write {_elementsCount} types of {eventData.Topic} in given format: 'result,result,result'",
                Model = "text-davinci-003",
                MaxTokens = 128
            });

            if (completionResponse.Choices is {Count: > 0})
            {
                var result = completionResponse.Choices[0].Text;
                _prompts = result.Split(',');
                PromptsCollected?.Invoke(_prompts);
                _imageGenerator.CreateImages(_prompts);
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}