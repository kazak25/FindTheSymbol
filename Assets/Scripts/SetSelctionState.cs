using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class SetSelctionState : MonoBehaviour, IStateWithContext<ModeSelection>
{
    [SerializeField] private GameObject _setSelectionObject;
    [SerializeField] private GameObject _loading;
    [SerializeField] private ScriptableObject _scriptableObject;
    [SerializeField] private GameObject _cell;
    [SerializeField] private SymbolsSetView _symbolsSetView;
    
    [SerializeField] private Canvas _setSelection;
    [SerializeField] private Canvas _startScreen;
    [SerializeField] private Canvas _standartScreen;
    
    [SerializeField]private ModeSelection _modeSelection;
    private StateMachine _stateMachine;
    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    

    public void Enter(ModeSelection modeSelection)
    {
        SetStandart(modeSelection);
    }

    private void SetStandart(ModeSelection modeSelection)
    {
        _modeSelection = modeSelection;
        _setSelectionObject.SetActive(true);
        AddStartIcons();
        SetSelection();
    }

    [UsedImplicitly] 
    public void HideLoading()
    {
        _loading.SetActive(false);
    }
    public void SetSelection()
    {
        for (var i = 0; i < _scriptableObject._icons.Count; i++)
        {
            var cell = Instantiate(_cell, _setSelection.transform);
            var setView = Instantiate(_symbolsSetView, cell.transform);
            setView.Initialize(_scriptableObject.AllObjects[i].First(), _scriptableObject.AllObjectsNames[i]);
            setView.name = _scriptableObject.AllObjectsNames[i];
        }
    }
    public void AddStartIcons()
    {
        for (int i = 0; i < _scriptableObject.AllObjects.Count; i++)
        {
            _scriptableObject._icons.Add(_scriptableObject.AllObjects[i].First()); 
        }
    }
    public void Exit()
    {
       // _canvasGroup.DOFade(0f,0.5f).OnComplete(() => _setSelectionObject.gameObject.SetActive(false));
    }
}
