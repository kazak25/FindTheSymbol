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
        [SerializeField] UnityEvent loadingImageCompleted;
        [SerializeField] UnityEvent loadingState;
        
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private DallEImagesSettings _imagesSettings;
        
        [SerializeField] private GameObject loadingLabel;
        [SerializeField] private GameObject _currentLevel;
        
        [SerializeField] private BoxCollider _currentLevelCollider;

        public int picturesCount;

        private OpenAIApi openai = new OpenAIApi();

        private void Start()
        {
            button.onClick.AddListener(SendImageRequest);
        }

        private async void SendImageRequest()
        {
            _sprite.sprite = null; //* подумать, куда закинуть отключение/включение  ВСЕХ кнопок 
            button.enabled = false;
            inputField.enabled = false;
            loadingLabel.SetActive(true); 

            for (int i = 0; i < picturesCount; i++)
            {
                var response = await openai.CreateImage(new CreateImageRequest
                {
                    Prompt = inputField.text,
                    Size = ImageSize.Size512
                });

                if (response.Data != null && response.Data.Count > 0)
                {
                    loadingState.Invoke();
                    using(var request = new UnityWebRequest(response.Data[0].Url))
                    {
                        request.downloadHandler = new DownloadHandlerBuffer();
                        request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                        request.SendWebRequest();

                        while (!request.isDone) await Task.Yield();
                        
                        var sprite = _imagesSettings.ImageSettings(request);
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
        }
    }
}
