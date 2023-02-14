using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartScreenView : MonoBehaviour
    {
        [SerializeField]
        private Image[] _gameSetsIcons;
        
    
        public void Initialize(GameSetData[] gameSetsData)
        {
            for (var i = 0; i < gameSetsData.Length; i++)
            {
                _gameSetsIcons[i].sprite = gameSetsData[i].GameSetView;
            }
        }
    }
}