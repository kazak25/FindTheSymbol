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
    public UnityEvent _PlayMode;
    private bool _isGameActive = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Raycast();
        }
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
            }
            
            
            
        }
    }


    private void ObjectsSelection(string name)
    {
        switch (name)
        {
            case "Cars": 
            {
                _setSelection.SetActive(false);
                _cellsSpawner.Easylevel(_scriptableObject._cars,3);
                _PlayMode.Invoke();
                _isGameActive = true;
                break;
            }
            case "Letters": 
            {
                _setSelection.SetActive(false);
                _cellsSpawner.Easylevel(_scriptableObject._letters,3);
                _PlayMode.Invoke();
                _isGameActive = true;
                break;
            }
            case "Numbers": 
            {
                _setSelection.SetActive(false);
                _cellsSpawner.Easylevel(_scriptableObject._numbers,3);
                _PlayMode.Invoke();
                _isGameActive = true;
                break;
            }
            default: return;
        }
    }
}
