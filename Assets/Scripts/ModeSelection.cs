using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class ModeSelection : MonoBehaviour
{
    public UnityEvent PlayMode;
    
    [SerializeField] private ScriptableObject _scriptableObject;
    [SerializeField] private GameState _gameState;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private SetSelctionState _setSelctionState;
    [SerializeField] private GameOverState _gameOverState;
    
    [SerializeField] private GameObject _setSelectionObject;
    
    public bool isGameActive = false;

    private void Start()
    {
        _stateMachine = new StateMachine(_setSelctionState, _gameState,_gameOverState);
        _stateMachine.Enter<SetSelctionState, ModeSelection>(this);
    }

    private void StartGame(IReadOnlyList<Sprite> sprites)
    {
        _setSelectionObject.SetActive(false);
        _gameState.Array(sprites);
        _stateMachine.Enter<GameState>();
        PlayMode.Invoke();
        isGameActive = true;
    }
    [UsedImplicitly]
    public void ObjectsSelection(string name)
    {
        switch (name)
        {
            case "Mystery":
            {
                StartGame(_scriptableObject.Mystery);
                break;
            }
            case "Animals":
            {
                StartGame(_scriptableObject.Animals);
                break;
            }
            case "Food":
            {
                StartGame(_scriptableObject.Food);
                break;
            }
            default: return;
        }
    }
    [UsedImplicitly]
    public void DalleStartGame()
    {
        StartGame(_scriptableObject.DalleImages);
    }
}
