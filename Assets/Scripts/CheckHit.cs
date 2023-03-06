using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class CheckHit : MonoBehaviour
{
    [SerializeField] private CellRotationController _cellRotationController;
    [SerializeField] private GameController _gameController;
    
    [SerializeField] private GameState _gameState;
    
    [SerializeField] private TaskSelection _gameMode;
    
    [SerializeField] private AudioSource _win;
    [SerializeField] private AudioSource _fail;
    
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
                _win.Play();
                _gameState.isWinCondition = true;
                var scale = hit.collider.gameObject.transform.localScale;
                _cellRotationController.ShowIcon(spriteRenderer,_gameState.isWinCondition);
                ScaleEffect(hit.collider.gameObject,scale);
                _gameState._levelNumber++;
                
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
                _fail.Play();
                _cellRotationController.ShowIcon(spriteRenderer,_gameState.isWinCondition);
            }
        }
    }

    private void ScaleEffect(GameObject gameObject,Vector3 scale)
    {
        gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 0), 1f).OnComplete(() =>
          gameObject.transform.DOScale(scale, 1f));
        
    }
    
    public void WinCondition()
    {
        _gameState.isWinCondition = false;
    }

    IEnumerator ShowButtonNextLevel()
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
