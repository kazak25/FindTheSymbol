using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class GameMode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private List<Sprite> _sprites;
    public string tempName { get ; private set; }
    private void Update()
    {
        
    }
    [UsedImplicitly]
    public void SearchObject()
    {
        var randomIndex = UnityEngine.Random.Range(0,_sprites.Count);
        tempName = _sprites[randomIndex].name;
        _text.text = "Find " + tempName;

    }
    public void Initialize(List<Sprite> sprites)
    {
        _sprites = sprites;
    }
    
}
