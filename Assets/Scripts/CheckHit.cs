using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CheckHit : MonoBehaviour
{
    
    [SerializeField] private GameController _gameController;
    
    [SerializeField] private GameState _gameState;
    
    [SerializeField] private TaskSelection _gameMode;
    
    [SerializeField] private TaskSelection _taskSelection;
    
    [SerializeField] private Image _dalleImage;
    
    [SerializeField] private ModeSelection _modeSelection;
   
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Raycast();
        }
    }
    
    private void Raycast()
    {
        if (_gameState.isWinCondition)
        {
            return;
        }
        if (_taskSelection._isCountDown)
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
                if (_gameState.isLastLevel)
                {
                    StartCoroutine(ShowButtonRestart());
                    return;
                }
                StartCoroutine(ShowButtonNextLevel());
            }
            
            if(_modeSelection.isGameActive && hit.collider.gameObject.name != _gameMode.tempName
               ||  spriteRenderer.sprite != _dalleImage.sprite)
            {
                _gameController.WrongSelection(spriteRenderer);
            }
        }
    }
    
    IEnumerator ShowButtonNextLevel()   //перенести в скрипт для  UI элементов
     {
        yield return new WaitForSeconds(2);
        _gameController._nextLevelbutton.SetActive(true);
    }
    IEnumerator ShowButtonRestart()
    {
        yield return new WaitForSeconds(2);
        _gameController._restartButton.SetActive(true);
    }
}
