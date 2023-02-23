using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScriptableObject : MonoBehaviour
{
    public IReadOnlyList<Sprite> Cars => _cars;
    public IReadOnlyList<Sprite> Letters => _letters;
    public IReadOnlyList<Sprite> Numbers => _numbers;
    public IReadOnlyList<List<Sprite>> AllObjects => _allObjects;
    public IReadOnlyList<string> AllObjectsNames => _allObjectsNames;
    
    [SerializeField] private List<Sprite> _cars;
    [SerializeField] private List<Sprite> _letters;
    [SerializeField] private List<Sprite> _numbers;
   
    private readonly List<List<Sprite>>_allObjects = new List<List<Sprite>>();
    private readonly List<string> _allObjectsNames = new List<string>();
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


