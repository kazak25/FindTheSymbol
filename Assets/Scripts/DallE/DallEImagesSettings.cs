using ScriptableObjects;
using UnityEngine;
using UnityEngine.Networking;

namespace DallE
{
    public class DallEImagesSettings : MonoBehaviour
    {
        [SerializeField] private SpriteModels _dalleImagesList;
        [SerializeField] private GameObject _currentLevel;
        [SerializeField] private BoxCollider _currentLevelCollider;

        private float _currentLevelScale = 0.35f;
        private float _currentLevelColliderSize = 500;

        public Sprite ImageSettings(UnityWebRequest request)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(request.downloadHandler.data);
            var sprite = Sprite.Create(texture, new Rect(0, 0, 512, 512), new Vector2(0.5f,0.5f), 1f);
            _currentLevel.transform.localScale = new Vector3(_currentLevelScale, _currentLevelScale, 0);
            _currentLevelCollider.size = new Vector3(_currentLevelColliderSize, _currentLevelColliderSize, 0);
            _dalleImagesList._dalleImages.Add(sprite);
            return sprite;
        }
    }
}

