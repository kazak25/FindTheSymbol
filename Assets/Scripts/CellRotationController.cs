using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CellRotationController : MonoBehaviour
{
    public void ShowIcon(SpriteRenderer sprite,bool isRightSprite)
    {
        if (isRightSprite)
        {
            sprite.DOColor(Color.white, 2);
        }
        else
        {
            sprite.DOColor(Color.white, 2).
                OnComplete(() => sprite.DOColor(Color.clear, 2));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
