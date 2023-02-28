using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Color = System.Drawing.Color;
using Random = UnityEngine.Random;

public class TaskSelection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private IReadOnlyList<Sprite> _sprites = new List<Sprite>();
    private readonly List<String> _spritesNames = new List<string>();
    
    private TextMeshPro _textName;
    public string tempName { get ; private set; }
   
    [UsedImplicitly]
    public void SearchObject()
    {
        
        var randomIndex = GetRandomName();
        tempName = _sprites[randomIndex].name;

        while (_spritesNames.Contains(tempName))
        {
            randomIndex = GetRandomName();
            tempName = _sprites[randomIndex].name;
        }
        _spritesNames.Add(tempName);
        UnityEngine.Color tempColor = Random.ColorHSV();
        _text.color = tempColor;
        _text.text = "Find " + tempName;
    }

    public void ListNameClear()
    {
        _spritesNames.Clear();
    }

    private int GetRandomName()
    {
      return  Random.Range(0,_spritesNames.Count);
    }
    public void Initialize(IReadOnlyList<Sprite> sprites)
    {
        _sprites = sprites;
    }
    
}
