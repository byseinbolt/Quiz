using UnityEngine;

[CreateAssetMenu(fileName = "Items",menuName = "Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private Sprite[] _sprite;
    

    public  Sprite[] Sprite => _sprite;
}