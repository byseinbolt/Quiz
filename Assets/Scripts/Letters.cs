using UnityEngine;

[CreateAssetMenu(fileName = "Letters",menuName = "Letter")]
public class Letters : ScriptableObject
{
    [SerializeField]
    private string _name;
    
    public string Name { get => _name; }

    [SerializeField]
    private Sprite _sprite;
    
    public Sprite Sprite { get => _sprite;}
    

}
