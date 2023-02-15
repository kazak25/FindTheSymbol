using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class RayCast : MonoBehaviour
{
    [SerializeField] private GameObject _setSelection;

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
            switch (name)
            {
                case "Cars": 
                {
                    _setSelection.SetActive(false);
                    Debug.Log("Cars(Clone)");
                    break;
                }
                case "Letters": 
                {
                    _setSelection.SetActive(false);
                    Debug.Log("Letters(Clone)");
                    break;
                }
                case "Numbers": 
                {
                    _setSelection.SetActive(false);
                    Debug.Log("Numbers(Clone)");
                    break;
                }
            }
            
            
        }
    }
    
    
    
}
