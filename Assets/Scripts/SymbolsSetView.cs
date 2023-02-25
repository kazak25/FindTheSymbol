using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class SymbolsSetView : MonoBehaviour
{
  
   
   
   [SerializeField] private SpriteRenderer _sprite;
   [SerializeField] private TextMeshProUGUI _name;


   [UsedImplicitly]
   public void Initialize(Sprite sprite)
   {
      _sprite.sprite = sprite;
   }
   [UsedImplicitly]
   public void Initialize( Sprite sprite, string name)
   {
      _sprite.sprite = sprite;
      _name.text = name;
   
   }
}
