using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class GameMode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private List<Sprite> _sprites=new List<Sprite>();
    private List<String> _spritesNames=new List<string>();
    public string tempName { get ; private set; }
    private void Update()
    {
        
    }
    [UsedImplicitly]
    public void SearchObject()
    {
        var randomIndex = RandomName();
        tempName = _sprites[randomIndex].name;

        while (_spritesNames.Equals(tempName))
        {
            randomIndex = RandomName();
            tempName = _sprites[randomIndex].name;
        }
        _spritesNames.Add(tempName);
        
        _text.text =  "Find " + tempName;
            

    }

    public void ListNameClear()
    {
        _spritesNames.Clear();
    }

    private int RandomName()
    {
      return  UnityEngine.Random.Range(0,_sprites.Count);
    }
    public void Initialize(List<Sprite> sprites)
    {
        _sprites = sprites;
    }
    
}
