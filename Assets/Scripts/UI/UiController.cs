using GameData;
using UnityEngine;

namespace UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField]
        private StartScreenController startScreenController;

        public void Initialize(DataProvider dataProvider)
        {
            startScreenController.Initialize(dataProvider.GameSetData);
        }
        
    }
}