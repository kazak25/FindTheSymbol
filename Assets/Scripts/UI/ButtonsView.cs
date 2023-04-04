using System.Collections;
using Events;
using JetBrains.Annotations;
using SimpleEventBus.Disposables;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonsView : MonoBehaviour
    {
        [SerializeField] private GameObject _nextLevelbutton;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private InputField _inputField; // перенести
        [SerializeField] private Button _button;  // перенести
        [SerializeField] private GameObject _loadingLabel;
    
        private CompositeDisposable _subscription;
    
        private void Start()
        {
            _subscription = new CompositeDisposable()
            {
                EventStream.Game.Subscribe<LoadingStageEvent>(DalleViewOff)
            };
        
            _button.onClick.AddListener(SendRequest);  // нужно перенести кнопку и подписаться в другом месте (например в юнити)
        
        }

        private void SendRequest()
        {
            var eventDataRequest = new GetRequestEvent(_inputField.text);
            EventStream.Game.Publish(eventDataRequest);
        
            var eventData = new SendRequestEvent();
            EventStream.Game.Publish(eventData);
        }
    
        [UsedImplicitly]
        private void DalleViewOff(LoadingStageEvent eventData)
        {
            _button.enabled = false;
            _inputField.enabled = false;
            _loadingLabel.SetActive(true); 
        }
    
    
        [UsedImplicitly]
        public void NextLevelCorutine()
        {
            StartCoroutine(ShowButtonNextLevel());
        }
        [UsedImplicitly]
        public void RestartCorutine()
        {
            StartCoroutine(ShowButtonRestart());
        }
        IEnumerator ShowButtonNextLevel()   //перенести в скрипт для  UI элементов
        {
            yield return new WaitForSeconds(2);
            _nextLevelbutton.SetActive(true);
        }
        IEnumerator ShowButtonRestart()
        {
            yield return new WaitForSeconds(2);
            _restartButton.SetActive(true);
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}
