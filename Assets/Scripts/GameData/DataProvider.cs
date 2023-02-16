using UnityEngine;

namespace GameData
{
    public class DataProvider : MonoBehaviour
    {
        public GameSetData[] GameSetData => _gameSetsData;

        public GameLevelSettings GameLevelSettings => _gameLevelSettings;
        
        [SerializeField]
        private GameSetData[] _gameSetsData;
        
        [SerializeField]
        private GameLevelSettings _gameLevelSettings;
    }
}