using System;
using UnityEngine;

namespace GameData
{ 
   [CreateAssetMenu(fileName = "GameItem", menuName = "GameItem")]
   public class GameItem : ScriptableObject,IComparable<GameItem> 
   { 
      public string ItemName => _itemName;
      public Sprite ItemView => _itemView;
      
      [SerializeField]
      private string _itemName; 
      
      [SerializeField]
      private Sprite _itemView;

      public int CompareTo(GameItem other)
      {
         if (_itemName == other.ItemName)
         {
            return 1;
         }
         return -1;
      }
   }
}
