using System;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "GameSetData",menuName = "GameSetData")]
    public class GameSetData : ScriptableObject
    {
        public Sprite GameSetView => _gameSetView;
        public GameItem[] GameItems => _gameItems;
        
        [SerializeField]
        private Sprite _gameSetView;
        [SerializeField]
        private GameItem[] _gameItems;
    }
}

    public class TestGameSetData : MonoBehaviour
    {
        
    }
