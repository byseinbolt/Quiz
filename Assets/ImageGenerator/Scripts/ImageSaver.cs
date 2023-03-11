using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ImageGenerator
{
    public class ImageSaver : MonoBehaviour
    {
        private readonly string _savePath = @"C:\AIImages\";
        
        [SerializeField]
        private string _name;
      
        public void SaveImage(Texture2D texture2D)
        {
            var textureBytes = texture2D.EncodeToPNG();
            File.WriteAllBytes(_savePath+_name+".png",textureBytes);
        }
    }
}