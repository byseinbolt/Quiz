﻿using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "GameItems", menuName = "GameSet")]
    public class GameSet : ScriptableObject
    {
        public string[] GameItemNames => _gameItemNames;
        public Sprite[] GameItemViews => _gameItemViews;
    
        [SerializeField]
        private string[] _gameItemNames;
        [SerializeField]
        private Sprite[] _gameItemViews;
    }
}