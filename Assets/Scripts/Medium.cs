using System.Collections.Generic;
using UnityEngine;

public class Medium : MonoBehaviour,StateMachine.Istate
{
    [SerializeField] private CellsSpawner _mediumLevel;
    [SerializeField] private GameObject _currentLevel;
    private StateMachine _stateMachine;
    private List<Sprite> _sprites = new List<Sprite>();

    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Array(List<Sprite> sprites)
    {
        _sprites = sprites;
    }
    
    public void Enter()
    {
        _mediumLevel.MediumLevel(_sprites,6);
    }

    public void Exit()
    {
        var s = _currentLevel.transform; // Получаем ссылку на родительский объект

        foreach (Transform child in s) // Проходимся по всем дочерним объектам
        {
            Destroy(child.gameObject); // Удаляем каждый из них
        }
    }
}