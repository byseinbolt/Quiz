using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "DataProvider", menuName = "DataProvider")]
    public class DataProvider : ScriptableObject
    {
        public IEnumerable<GameSetData> GameSetData => _gameSetsData;

        public GameLevelSettings GameLevelSettings => _gameLevelSettings;
        
        [SerializeField]
        private GameSetData[] _gameSetsData;
        
        [SerializeField]
        private GameLevelSettings _gameLevelSettings;
    }
}