using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class CheckHit : MonoBehaviour
{
    public UnityEvent _showNextButton;
    
    [SerializeField] private GameController _gameController;
    
    [SerializeField] private GameState _gameState;
    
    [SerializeField] private TaskSelection _gameMode;
    
    [SerializeField] private TaskSelection _taskSelection;
    
    [SerializeField] private Image _dalleImage;
    
    [SerializeField] private ModeSelection _modeSelection;

    [SerializeField] private GameOverState _gameOverState;

    [SerializeField] private ParticleSystem _stars;
   
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Raycast();
        }
    }
    
    private void Raycast()
    {
        if (_gameState.isWinCondition || _taskSelection._isCountDown )
        {
            return;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 10000))
        {
            var name = hit.collider.gameObject.name;
            var spriteRenderer = hit.collider.gameObject.GetComponent<SpriteRenderer>();
           _modeSelection.ObjectsSelection(name);
            
            if (_modeSelection.isGameActive &&  spriteRenderer.sprite == _dalleImage.sprite)
            {
                _gameController.RightSelection(hit.collider.gameObject.transform, spriteRenderer,
                    hit.collider.gameObject);
                var stars = Instantiate(_stars, hit.collider.gameObject.transform);
                stars.Play();
                if (_gameState.isLastLevel)
                {
                    _gameOverState.Enter();
                    return;
                }
                
                _showNextButton.Invoke();
            }
            
            if(_modeSelection.isGameActive && hit.collider.gameObject.name != _gameMode.tempName
               ||  spriteRenderer.sprite != _dalleImage.sprite)
            {
                _gameController.WrongSelection(spriteRenderer);
            }
        }
    }
}
