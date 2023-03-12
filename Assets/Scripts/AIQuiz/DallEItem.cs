using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace AIQuiz
{
    public class DallEItem : MonoBehaviour
    {
        public string Name { get; private set; }
        public Button Button => _button;

        public Image Image => _image;
        
        [SerializeField]
        private Image _image;
        
        [SerializeField]
        private Button _button;
        
        private Action<DallEItem> _onCLicked;

        public void Initialize(string itemName, Sprite itemView)
        {
            Name = itemName;
            _image.sprite = itemView;
            _button.onClick.AddListener(Click);
        }
    
        private void Click()
        {
            _onCLicked?.Invoke(this);
        }

        public void SetClickCallBack(Action<DallEItem> onClicked)
        {
            _onCLicked = onClicked;
        }
    }
}