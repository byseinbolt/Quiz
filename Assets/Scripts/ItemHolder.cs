using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    public Image Image => _image;
    public GameSet GameSet => _gameSet;

    [SerializeField]
    private Image _image;
    [SerializeField]
    private GameSet _gameSet;
}