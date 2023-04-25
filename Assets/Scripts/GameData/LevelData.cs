using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "LevelName", menuName = "Level")]
    public class LevelData : ScriptableObject
    {
        public int ElementsCount => _elementsCount;
    
        [SerializeField]
        private string _levelName;
        
        [SerializeField]
        private int _elementsCount;
    }
}