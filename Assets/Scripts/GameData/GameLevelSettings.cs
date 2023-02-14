using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "GameLevelSettings", menuName = "GameLevelSettings")]
    public class GameLevelSettings : ScriptableObject
    {
        public LevelData[] Levels => _levels;
    
        [SerializeField]
        private LevelData[] _levels;
    }
}