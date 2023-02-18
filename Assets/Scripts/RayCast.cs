using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class RayCast : MonoBehaviour
{
    [SerializeField] private GameObject _setSelection;
    [SerializeField] private ScriptableObject _scriptableObject;
    [SerializeField] private CellsSpawner _cellsSpawner;
    [SerializeField] private GameMode _gameMode;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private Easy _easyLevelState;
    [SerializeField] private Medium _mediumLevelState;
    [SerializeField] private Hard _hardLevelState;
    [SerializeField] private GameObject _nextLevelbutton;
    [SerializeField] private GameObject _restartButton;
    public UnityEvent _PlayMode;
    private bool _isGameActive = false;
    private int _levelNumber;
    private bool isLastLevel = false;
    private bool _isWinCondition = false;
    [SerializeField] private AudioSource _win;
    [SerializeField] private AudioSource _fail;
    [SerializeField] private CanvasGroup _canvasGroup;
    

    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Raycast();
        }
    }

    private void Start()
    {
        _stateMachine = new StateMachine(_easyLevelState, _mediumLevelState, _hardLevelState);
        BlackOut();
    }

    private void Raycast()
    {
        if (_isWinCondition)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000))
        {
            var startPosition = hit.collider.gameObject.transform.position;
            var name = hit.collider.gameObject.name;
            ObjectsSelection(name);
            if (_isGameActive && hit.collider.gameObject.name == _gameMode.tempName)
            {
                _win.Play();
                _isWinCondition = true;
                var scale = hit.collider.gameObject.transform.localScale;
                hit.collider.gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 0), 1f).OnComplete(() =>
                    hit.collider.gameObject.transform.DOScale(scale, 1f));

                _levelNumber++;
                if (isLastLevel)
                {
                    StartCoroutine(ShowButtonRestart());

                    return;
                }

                StartCoroutine(ShowButtonNextLevel());

            }

            else
            {
                _fail.Play();
                hit.collider.gameObject.transform.DOShakePosition(1f, 0.5f)
                    .OnComplete(() => hit.collider.gameObject.transform.position = startPosition);
            }
        }
    }

    public void BlackOut()
    {
        _canvasGroup.DOFade(1, 5f);
    }

    public void WinCondition()
    {
        _isWinCondition = false;
    }

    IEnumerator ShowButtonNextLevel()
    {
        yield return new WaitForSeconds(2);
        _nextLevelbutton.SetActive(true);
    }
    IEnumerator ShowButtonRestart()
    {
        yield return new WaitForSeconds(2);
        _restartButton.SetActive(true);
    }
    
    public void ChangeLevel()
    {
        switch (_levelNumber)
        {
            case 1:
            {
                _stateMachine.Enter<Medium>();
                _nextLevelbutton.SetActive(false);
                _PlayMode.Invoke();
                break;
            }
            case 2:
            {
                _stateMachine.Enter<Hard>();
                isLastLevel = true;
                _nextLevelbutton.SetActive(false);
                _PlayMode.Invoke();
                break;
            }
           default: return;
               
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(GlobalConstants.SceneGame);
    }


    private void ObjectsSelection(string name)
    {
        switch (name)
        {
            case "Cars": 
            {
                _setSelection.SetActive(false);
                _easyLevelState.Array(_scriptableObject._cars);
                _mediumLevelState.Array(_scriptableObject._cars);
                _hardLevelState.Array(_scriptableObject._cars);
                _stateMachine.Enter<Easy>();
                _PlayMode.Invoke();
                _isGameActive = true;
                break;
            }
            case "Letters": 
            {
                _setSelection.SetActive(false);
                _easyLevelState.Array(_scriptableObject._letters);
                _mediumLevelState.Array(_scriptableObject._letters);
                _hardLevelState.Array(_scriptableObject._letters);
                _stateMachine.Enter<Easy>();
                _PlayMode.Invoke();
                _isGameActive = true;
                break;
            }
            case "Numbers": 
            {
                _setSelection.SetActive(false);
                _easyLevelState.Array(_scriptableObject._numbers);
                _mediumLevelState.Array(_scriptableObject._numbers);
                _hardLevelState.Array(_scriptableObject._numbers);
                _stateMachine.Enter<Easy>();
                _PlayMode.Invoke();
                _isGameActive = true;
                break;
            }
            default: return;
        }
    }
}
