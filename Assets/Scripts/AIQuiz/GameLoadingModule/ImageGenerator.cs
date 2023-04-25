using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenAI;
using UnityEngine;
using UnityEngine.Networking;
using Utilities;

namespace AIQuiz.GameLoadingModule
{
    public class ImageGenerator : MonoBehaviour
    {
        public event Action<Dictionary<string,Sprite>> ImagesLoaded;
        private readonly OpenAIApi _openai = new();
        
        public async void CreateImages(IEnumerable<string> prompts)
        {
            var imageStyle = PromptHelper.Styles.GetRandomItem();
            var images = new Dictionary<string, Sprite>();
            
            foreach (var prompt in prompts)
            {
                var dallEResponse = await _openai.CreateImage(new CreateImageRequest
                {
                    Prompt = $"{prompt} in {imageStyle} style with thematic background",
                    Size = ImageSize.Size256
                });

                if (dallEResponse.Data is {Count: > 0})
                {
                    using var request = new UnityWebRequest(dallEResponse.Data[0].Url);
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                    request.SendWebRequest();

                    while (!request.isDone) await Task.Yield();

                    var sprite = CreateSprite(request);
                    images.Add(prompt,sprite);
                }
                else
                {
                    Debug.LogWarning("No image was created from this prompt.");
                }
            }
            
            ImagesLoaded?.Invoke(images);
            
        }
        
        private Sprite CreateSprite(UnityWebRequest request)
        {
            var texture = new Texture2D(2, 2);
            texture.LoadImage(request.downloadHandler.data);
            var sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), Vector2.zero, 1f);
            return sprite;
        }
    }
}