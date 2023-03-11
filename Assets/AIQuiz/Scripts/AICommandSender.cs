using System;
using System.Collections.Generic;
using OpenAI;
using UnityEngine;

namespace AIQuiz.Scripts
{
    public class AICommandSender : MonoBehaviour
    {
        public event Action<IReadOnlyList<string>> ResultCollected;
        
        private string _userInput;
        private IReadOnlyList<string> _prompts;
        private readonly OpenAIApi _openAI = new();

        public void Initialize(string userInput)
        {
            _userInput = userInput;
        }

        public async void SendCommandToAI()
        {
            var completionResponse = await _openAI.CreateCompletion(new CreateCompletionRequest
            {
                Prompt = $"{Convert.ToString(GlobalConstants.ELEMENTS_COUNT)} types of {_userInput} in format: 'result,result,result'",
                Model = "text-davinci-003",
                MaxTokens = 128,
                Temperature = 0.7f,
                BestOf = 1,
                FrequencyPenalty = 0,
                PresencePenalty = 0,
            
            });
         
            if (completionResponse.Choices is {Count: > 0})
            {
                var result = completionResponse.Choices[0].Text;
                _prompts = result.Split(',');
                ResultCollected?.Invoke(_prompts);
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }
        }

    }
}