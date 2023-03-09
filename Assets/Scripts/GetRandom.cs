using System.Collections.Generic;
using UnityEngine;

public class GetRandom : MonoBehaviour
{
    public IReadOnlyList<T> GetRandomObject<T>(IReadOnlyList<T> sprites, int cellCount)
    {
        List<T> tempSprites = new List<T>();
        IReadOnlyList<T> newSprites = new List<T>();
        for (int i = 0; i < cellCount; i++)
        {
            while (true)
            {
                var tempIndex = Random.Range(0, sprites.Count);
                var randomSprite = sprites[tempIndex];
                if (!tempSprites.Contains(randomSprite))
                {
                    tempSprites.Add(randomSprite);
                    break;
                }
            }
        }

        newSprites = tempSprites;
        return newSprites;
    }
   
}
