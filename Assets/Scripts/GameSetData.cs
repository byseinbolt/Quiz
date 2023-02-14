using UnityEngine;

[CreateAssetMenu(fileName = "GameSetData",menuName = "GameSetData")]
public class GameSetData : ScriptableObject
{ 
    //public string GameSetName => _gameSetName;
    public Sprite GameSetView => _gameSetView;
    public GameSet GameSet => _gameSet;
    
    // [SerializeField]
    // private string _gameSetName;
    [SerializeField]
    private Sprite _gameSetView;
    [SerializeField]
    private GameSet _gameSet;
}