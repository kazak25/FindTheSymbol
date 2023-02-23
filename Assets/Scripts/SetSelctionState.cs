using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SetSelctionState : MonoBehaviour, IStateWithContext<GameController>
{
    [SerializeField] private GameObject _setSelectionObject;
    [SerializeField] private CanvasGroup _canvasGroup;

    private GameController _gameController;
    
    private StateMachine _stateMachine;
    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter(GameController gameController)
    {
        _gameController = gameController;
        _setSelectionObject.SetActive(true);
        _canvasGroup.DOFade(1, 3f);
        _gameController.AddStartIcons();
       // _gameController.SetSe
        
    }
   

    public void Exit()
    {
        _canvasGroup.DOFade(0f,0.5f).OnComplete(() => _setSelectionObject.gameObject.SetActive(false));
    }
}
