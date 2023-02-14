using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cell;
    private float _x = -3;
    private float _y = 3;
    private void Start()
    {
        Easylevel();

    }

    private void Easylevel()
    {
        for (int i = 0; i < 3; i++)
        {
            var cell = Instantiate(_cell);
            _cell.transform.position = new Vector3(_x, 0, 0);
            _x += 3;
        }
    }
    
    private void MediumLevel()
    {
        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < 3; i++)
            {
                var cell = Instantiate(_cell);
                _cell.transform.position = new Vector3(_x, _y, 0);
                _x += 3;
            }
            _x = -3;
            _y -= 3;
        }
       
    }
    private void HardLevel()
    {
        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < 3; i++)
            {
                var cell = Instantiate(_cell);
                _cell.transform.position = new Vector3(_x, _y, 0);
                _x += 3;
            }
            _x = -3;
            _y -= 3;
        }
    }
}
