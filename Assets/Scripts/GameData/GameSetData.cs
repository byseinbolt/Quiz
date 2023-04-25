using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "GameSetData", menuName = "GameSetData")]
    public class GameSetData : ScriptableObject
    {
        public Sprite GameSetView => _gameSetView;
        
        public IReadOnlyList<GameItem> GameItems => _gameItems;

        [SerializeField]
        private string _gameSetName;

        [SerializeField]
        private Sprite _gameSetView;

        [SerializeField
        ] private List<GameItem> _gameItems;
    }
}
