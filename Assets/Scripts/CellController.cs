using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CellController : MonoBehaviour
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
    public void ScaleEffect(GameObject gameObject,Vector3 scale)
    {
        gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 0), 1f).OnComplete(() =>
            gameObject.transform.DOScale(scale, 1f));
        
    }
    
}
