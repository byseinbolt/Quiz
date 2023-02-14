using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "GameSetData",menuName = "GameSetData")]
    public class GameSetData : ScriptableObject
    {
        public Sprite GameSetView => _gameSetView;
        public GameSet GameSet => _gameSet;

        public GameItem[] _gameItems;
        
        [SerializeField]
        private Sprite _gameSetView;
        [SerializeField]
        private GameSet _gameSet;
    }
}