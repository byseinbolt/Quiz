using Events;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Cell : MonoBehaviour
{
    public Image Image => _image;
    public Button Button => _button;
    
    [SerializeField]
    private Image _image;
    
    [SerializeField]
    private Image _background;
    
    [SerializeField]
    private Button _button;
    
    [SerializeField]
    private ColorProvider _colorProvider;
    
    public void Initialize(Sprite gameItemView)
    {
        _image.sprite = gameItemView;
        _background.color = _colorProvider.GetRandomColor();
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnClick()
    {
        EventStreams.Game.Publish(new CellClickedEvent(this));
    }
}