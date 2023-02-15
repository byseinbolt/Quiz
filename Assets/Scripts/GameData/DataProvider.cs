using UnityEngine;

namespace GameData
{
    public class DataProvider : MonoBehaviour
    {
        [SerializeField]
        private GameSetData[] _gameSetsData;
        [SerializeField]
        private GameLevelSettings _gameLevelSettings;
    }
}