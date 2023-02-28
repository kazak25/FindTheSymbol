using System.Collections;
using DG.Tweening;
using UnityEngine;


public class CheckHit : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameState _gameState;
    [SerializeField] private TaskSelection _gameMode;
    [SerializeField] private AudioSource _win;
    [SerializeField] private AudioSource _fail;
   

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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 10000))
        {
            Debug.Log("kek");
            var startPosition = hit.collider.gameObject.transform.position;
            var name = hit.collider.gameObject.name;
            _gameController.ObjectsSelection(name);
            
            if (_gameController._isGameActive && hit.collider.gameObject.name == _gameMode.tempName)
            {
                _win.Play();
                _gameState.isWinCondition = true;
                var scale = hit.collider.gameObject.transform.localScale;
                hit.collider.gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 0), 1f).OnComplete(() =>
                    hit.collider.gameObject.transform.DOScale(scale, 1f));
                _gameState._levelNumber++;
                
                if (_gameState.isLastLevel)
                {
                    StartCoroutine(ShowButtonRestart());
                    return;
                }
                
                StartCoroutine(ShowButtonNextLevel());
            }
            
            if(_gameController._isGameActive && hit.collider.gameObject.name != _gameMode.tempName)
            {
                _fail.Play();
                var sprite = hit.collider.gameObject.transform;
                var rotation = sprite.GetComponentInChildren<SpriteRenderer>();
                rotation.flipX = true;


                // hit.collider.gameObject.transform.DORotate(new Vector3(0, 180, 0), 3);




                //.OnComplete(() => hit.collider.gameObject.transform.position = startPosition);
            }
        }
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
