using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace AIQuiz.Scripts
{
    public class ImageInstance : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _background;
        [SerializeField] private ColorProvider _colorProvider;
        
        public void Initialize(Sprite sprite)
        {
            _background.color = _colorProvider.GetRandomColor();
            _image.sprite = sprite;
        }
    }
}