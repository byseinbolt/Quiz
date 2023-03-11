using System.Collections.Generic;
using System.Threading.Tasks;
using AIQuiz.Scripts.Events;
using OpenAI;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

//TODO: РАЗБИТЬ НА РАЗНЫЕ КЛАССЫ
namespace AIQuiz.Scripts
{
   public class ImageGenerator : MonoBehaviour
   {
      [SerializeField]
      private TextMeshProUGUI _goalLabel;
      
      private string _userInput;
      private OpenAIApi _openAI = new();
      private IReadOnlyList<string> _prompts;
      
      
      private int _numbers;
      
      private async void SendImageRequest(IEnumerable<string> prompts)
      {
         var style = GetRandomString(PromptHelper.Styles);
         foreach (var result in prompts)
         {
            var response = await _openAI.CreateImage(new CreateImageRequest
            {
               Prompt = $"{result} in {style} style, with thematic background without labels",
               Size = ImageSize.Size256
            });

            if (response.Data is {Count: > 0})
            {
               using var request = new UnityWebRequest(response.Data[0].Url);
               request.downloadHandler = new DownloadHandlerBuffer();
               request.SetRequestHeader("Access-Control-Allow-Origin", "*");
               request.SendWebRequest();

               while (!request.isDone) await Task.Yield();

               var sprite = GetSprite(request);
               EventStreams.AIQuiz.Publish(new ImageLoadedEvent(sprite));
               Debug.Log(result);

            }
            else
            {
               Debug.LogWarning("No image was created from this prompt.");
            }
         }
         
         _goalLabel.text = $"Find {GetRandomString(_prompts)}";
      }
      
      private Sprite GetSprite(UnityWebRequest request)
      {
         var texture = new Texture2D(2, 2);
         texture.LoadImage(request.downloadHandler.data);
         var sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), Vector2.zero, 1f);
         return sprite;
      }
      
      private string GetRandomString(IReadOnlyList<string> list)
      {
         var randomIndex = Random.Range(0, list.Count-1);
         return list[randomIndex];
      }

      
   }
}