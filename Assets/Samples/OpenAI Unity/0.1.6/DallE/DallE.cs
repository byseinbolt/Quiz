using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;
using ImageGenerator;


namespace OpenAI
{
    public class DallE : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [SerializeField] private GameObject loadingLabel;
        [SerializeField] private ImageSaver _imageSaver;

        private OpenAIApi openai = new OpenAIApi();

        private void Start()
        {
            button.onClick.AddListener(SendImageRequest);
        }

        private async void SendImageRequest()
        {
            image.sprite = null;
            button.enabled = false;
            inputField.enabled = false;
            loadingLabel.SetActive(true);

            var response = await openai.CreateImage(new CreateImageRequest
            {
                Prompt = inputField.text,
                Size = ImageSize.Size1024
            });

            if (response.Data is {Count: > 0})
            {
                using var request = new UnityWebRequest(response.Data[0].Url);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                request.SendWebRequest();

                while (!request.isDone) await Task.Yield();

                var texture = new Texture2D(2, 2);
                texture.LoadImage(request.downloadHandler.data);
                _imageSaver.SaveImage(texture);
                var sprite = Sprite.Create(texture, new Rect(0, 0, 1024, 1024), Vector2.zero, 1f);
                image.sprite = sprite;
            }
            else
            {
                Debug.LogWarning("No image was created from this prompt.");
            }

            button.enabled = true;
            inputField.enabled = true;
            loadingLabel.SetActive(false);
        }
    }
}
