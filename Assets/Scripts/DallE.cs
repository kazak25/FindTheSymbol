using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace OpenAI
{
    public class DallE : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private GameObject loadingLabel;
        [SerializeField] UnityEvent loadingImageCompleted;
        [SerializeField] private GameObject _currentLevel;
        [SerializeField] private BoxCollider _currentLevelCollider;
        
        public IReadOnlyList<Sprite> DalleImage => _dalleImage;

        [SerializeField] List<Sprite> _dalleImage = new List<Sprite>();
        private OpenAIApi openai = new OpenAIApi();

        private void Start()
        {
            button.onClick.AddListener(SendImageRequest);
        }

        private async void SendImageRequest()
        {
            _sprite.sprite = null;
            button.enabled = false;
            inputField.enabled = false;
            loadingLabel.SetActive(true);

            for (int i = 0; i < 9; i++)
            {
                var response = await openai.CreateImage(new CreateImageRequest
                {
                    Prompt = inputField.text,
                    Size = ImageSize.Size512
                });

                if (response.Data != null && response.Data.Count > 0)
                {
                    using(var request = new UnityWebRequest(response.Data[0].Url))
                    {
                        request.downloadHandler = new DownloadHandlerBuffer();
                        request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                        request.SendWebRequest();

                        while (!request.isDone) await Task.Yield();

                        Texture2D texture = new Texture2D(1, 1);
                        texture.LoadImage(request.downloadHandler.data);
                       var sprite = Sprite.Create(texture, new Rect(0, 0, 512, 512), new Vector2(0.5f,0.5f), 1f);
                       _currentLevel.transform.localScale = new Vector3(0.35f, 0.35f, 0);
                       _currentLevelCollider.size = new Vector3(500, 500, 0);
                        _dalleImage.Add(sprite);
                        _sprite.sprite = sprite;
                      


                    }
                }
                else
                {
                    Debug.LogWarning("No image was created from this prompt.");
                    i--;
                }
            }
            loadingImageCompleted.Invoke();
            
            
            

            button.enabled = true;
            inputField.enabled = true;
            loadingLabel.SetActive(false);
        }
    }
}
