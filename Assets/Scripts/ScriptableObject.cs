using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScriptableObject : MonoBehaviour
{
    
    public IReadOnlyList<Sprite> Mystery => _mystery;
    public IReadOnlyList<Sprite> Animals => _animals;
    public IReadOnlyList<Sprite> Food => _food;
    
    public IReadOnlyList<List<Sprite>> AllObjects => _allObjects;
    public IReadOnlyList<string> AllObjectsNames => _allObjectsNames;

    [SerializeField] private List<Sprite> _mystery;
    [SerializeField] private List<Sprite> _animals;
    [SerializeField] private List<Sprite> _food;

    private readonly List<List<Sprite>>_allObjects = new List<List<Sprite>>();
    private readonly List<string> _allObjectsNames = new List<string>();
    
    private void Awake()
    {
        
        _allObjects.Add(_mystery);
        _allObjects.Add(_animals);
        _allObjects.Add(_food);
        _allObjectsNames.Add("Mystery");
        _allObjectsNames.Add("Animals");
        _allObjectsNames.Add("Food");
        
    }
}



