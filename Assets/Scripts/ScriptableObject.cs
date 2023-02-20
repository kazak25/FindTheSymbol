using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScriptableObject : MonoBehaviour
{
    [SerializeField] public List<Sprite> _cars;
    [SerializeField] public List<Sprite> _letters;
    [SerializeField] public List<Sprite> _numbers;
   
    public List<List<Sprite>>_allObjects = new List<List<Sprite>>();
    public List<string> _allObjectsNames = new List<string>();
    private void Awake()
    {

        _allObjects.Add(_cars);
        _allObjects.Add(_letters);
        _allObjects.Add(_numbers);
        _allObjectsNames.Add("Cars");
        _allObjectsNames.Add("Letters");
        _allObjectsNames.Add("Numbers");
    }
}


