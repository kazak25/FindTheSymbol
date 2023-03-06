using System.Collections;
using System.Collections.Generic;
using OpenAI;
using UnityEngine;
using UnityEngine.Networking;

public class DallEImagesSettings : MonoBehaviour
{
    [SerializeField] private ScriptableObject _dalleImagesList;
    [SerializeField] private GameObject _currentLevel;
    [SerializeField] private BoxCollider _currentLevelCollider;
    
    public Sprite ImageSettings(UnityWebRequest request)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(request.downloadHandler.data);
        var sprite = Sprite.Create(texture, new Rect(0, 0, 512, 512), new Vector2(0.5f,0.5f), 1f);
        _currentLevel.transform.localScale = new Vector3(0.35f, 0.35f, 0);
        _currentLevelCollider.size = new Vector3(500, 500, 0);
        _dalleImagesList._dalleImages.Add(sprite);
        return sprite;
    }
}

