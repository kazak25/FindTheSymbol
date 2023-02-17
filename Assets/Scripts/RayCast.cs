using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class RayCast : MonoBehaviour
{
    [SerializeField] private GameObject _setSelection;
    [SerializeField] private ScriptableObject _scriptableObject;
    [SerializeField] private CellsSpawner _cellsSpawner;
    [SerializeField] private GameMode _gameMode;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private Easy _easyLevelState;
    [SerializeField] private Medium _mediumLevelState;
    [SerializeField] private Hard _hardLevelState;
    public UnityEvent _PlayMode;
    private bool _isGameActive = false;
    private int _levelNumber;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Raycast();
        }
    }

    private void Start()
    {
        _stateMachine = new StateMachine(_easyLevelState,_mediumLevelState,_hardLevelState);
    }

    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000))
        {
            var name = hit.collider.gameObject.name;
            ObjectsSelection(name);
            if (_isGameActive == true && hit.collider.gameObject.name == _gameMode.tempName )
            {
                Debug.Log("Мдээээ");
                _levelNumber++;
                ChangeLevel(_levelNumber);
            }
        }
    }

    private void ChangeLevel(int n)
    {
        switch (n)
        {
            case 1:
            {
                _stateMachine.Enter<Medium>();
                break;
            }
            case 2:
            {
                _stateMachine.Enter<Hard>();
                break;
            }
           default: return;
               
        }
    }


    private void ObjectsSelection(string name)
    {
        switch (name)
        {
            case "Cars": 
            {
                _setSelection.SetActive(false);
                _easyLevelState.Array(_scriptableObject._cars);
                _mediumLevelState.Array(_scriptableObject._cars);
                _hardLevelState.Array(_scriptableObject._cars);
                _stateMachine.Enter<Easy>();
                _PlayMode.Invoke();
                _isGameActive = true;
                break;
            }
            case "Letters": 
            {
                _setSelection.SetActive(false);
                _easyLevelState.Array(_scriptableObject._letters);
                _mediumLevelState.Array(_scriptableObject._letters);
                _hardLevelState.Array(_scriptableObject._letters);
                _stateMachine.Enter<Easy>();
                _PlayMode.Invoke();
                _isGameActive = true;
                break;
            }
            case "Numbers": 
            {
                _setSelection.SetActive(false);
                _easyLevelState.Array(_scriptableObject._numbers);
                _mediumLevelState.Array(_scriptableObject._numbers);
                _hardLevelState.Array(_scriptableObject._numbers);
                _stateMachine.Enter<Easy>();
                _PlayMode.Invoke();
                _isGameActive = true;
                break;
            }
            default: return;
        }
    }
}
