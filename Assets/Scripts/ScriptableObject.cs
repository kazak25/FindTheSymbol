using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScriptableObject : MonoBehaviour
{
    public IReadOnlyList<Sprite> Mystery => _mystery;
    public IReadOnlyList<Sprite> Animals => _animals;
    public IReadOnlyList<Sprite> Food => _food;
    public IReadOnlyList<Sprite> DalleImages => _dalleImages;
    public IReadOnlyList<List<Sprite>> AllObjects => _allObjects;
    public IReadOnlyList<string> AllObjectsNames => _allObjectsNames;
    public IReadOnlyList<Sprite> Icons => _icons;
    public IReadOnlyList<GameObject> Cells => _cells;
    public IReadOnlyList<Sprite> Sprites => _sprites;
    public IReadOnlyList<String> SpritesName => _spritesNames;
    public IReadOnlyList<Sprite> TempDalleSprites => _tempDalleSprites;


    [SerializeField] private List<Sprite> _mystery;
    [SerializeField] private List<Sprite> _animals;
    [SerializeField] private List<Sprite> _food;
    [SerializeField] public List<Sprite> _dalleImages;
    [SerializeField] public List<Sprite> _icons;
    
    public List<GameObject> _cells;
    
    public List<Sprite> _sprites = new List<Sprite>();
    public  List<String> _spritesNames = new List<string>();
    public List<Sprite> _tempDalleSprites = new List<Sprite>();
    
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

    public void ListClear<T>(List<T> list)
    {
        list.Clear();
    }

   
}



