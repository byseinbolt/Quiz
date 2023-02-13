using UnityEngine;

[CreateAssetMenu(fileName = "Letters",menuName = "Letter")]
public class Item : ScriptableObject
{
    public string Name { get => _name; }
    public Sprite Sprite { get => _sprite;}
    
    [SerializeField]
    private string _name;
    [SerializeField]
    private Sprite _sprite;
}