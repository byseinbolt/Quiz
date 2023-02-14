using UnityEngine;

[CreateAssetMenu(fileName = "GameItem", menuName = "GameItem")]
public class GameItem : ScriptableObject
{
    public string ItemName => _itemName;

    public Sprite ItemView => _itemView;

    [SerializeField] private string _itemName;

    [SerializeField] private Sprite _itemView;
}