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
    public IReadOnlyList<GameObject> Test => _TEST;

    [SerializeField] private List<Sprite> _cars;
    [SerializeField] private List<Sprite> _letters;
    [SerializeField] private List<Sprite> _numbers;
    [SerializeField] private List<GameObject> _TEST;

    private readonly List<List<Sprite>>_allObjects = new List<List<Sprite>>();
    private readonly List<string> _allObjectsNames = new List<string>();
    
    public  List<List<GameObject>> allGameofects = new List<List<GameObject>>();
    
    private void Awake()
    {
        allGameofects.Add(_TEST);
        _allObjects.Add(_cars);
        _allObjects.Add(_letters);
        _allObjects.Add(_numbers);
        _allObjectsNames.Add("Cars");
        _allObjectsNames.Add("Letters");
        _allObjectsNames.Add("Numbers");
        _allObjectsNames.Add("ЫЫЫ");
    }
}



