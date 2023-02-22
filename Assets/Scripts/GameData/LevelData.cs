using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "LevelName", menuName = "Level")]
    public class LevelData : ScriptableObject
    {
        public string LevelName => _levelName;
        
        public int LevelElementsCount => _levelElementsCount;
    
        [SerializeField]
        private string _levelName;
        
        [SerializeField]
        private int _levelElementsCount;
    }
}