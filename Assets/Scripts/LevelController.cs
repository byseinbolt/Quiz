using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using GameData;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Cell> _levelCompleted;
    
    [SerializeField]
    private UnityEvent<string> _goalSelected;
    
    private CellSpawner _cellSpawner;
    private GameItem _goalItem;
    
    private void Awake()
    {
        _cellSpawner = GetComponent<CellSpawner>();
    }

    private void Start()
    {
        _cellSpawner.OnClicked += OnCellClicked;
    }
    
    public void StartLevel(IReadOnlyList<GameItem> selectedGameSet, LevelData currentLevel)
    {
         StartCoroutine(_cellSpawner.Spawn(selectedGameSet, currentLevel));
        _goalItem = GetGoal(_goalItem);
        _goalSelected.Invoke(_goalItem.ItemName);
    }
    
    private void OnCellClicked(Cell cell)
    {
        if (cell.Image.sprite == _goalItem.ItemView)
        {
            cell.Image.rectTransform.DOScale(Vector3.zero, 1.5f)
                .SetEase(Ease.InBounce)
                .OnComplete(() => _levelCompleted.Invoke(cell));
        }
        else
        {
            var button = cell.GetComponent<Button>();
            PlayRotationAnimation(cell, button);
        }
    }
    //1. Изменить метод GetGoal(изменен) and убрать его из этого класса
    //2. Внедрить стейт машину
    //3. Сделать метод расширения для List<T>
    //4. Подумать куда вынести настройки бека в Cell
    //5. Изменить логику спавна in Cellspawner
    private GameItem GetGoal(GameItem previous)
    {
        var items = _cellSpawner.UsedItems.Where(item => item != previous).ToList();
        var randomIndex = Random.Range(0, items.Count);
        return items[randomIndex];
    }
    
    private void OnDestroy()
    {
        _cellSpawner.OnClicked -= OnCellClicked;
    }

    private void PlayRotationAnimation(Cell cell, Button button)
    {
        button.interactable = false;
        cell.Image.rectTransform.DORotate(new Vector3(0, 180, 0), 0.5f)
            .SetEase(Ease.InBounce)
            .SetLoops(2, LoopType.Yoyo)
            .OnComplete(() => button.interactable = true);
    }
    
}