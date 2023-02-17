using System;
using System.Collections.Generic;
using UnityEngine;

public class Easy : MonoBehaviour,StateMachine.Istate
{
    [SerializeField] private CellsSpawner _easyLevel;
    [SerializeField] private GameObject _currentLevel;
    private StateMachine _stateMachine;
    private List<Sprite> _sprites = new List<Sprite>();

    private void Start()
    {
       // _stateMachine = new StateMachine();
    }

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
        _easyLevel.Easylevel(_sprites,3);
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