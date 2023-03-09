using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverState : MonoBehaviour,IStateWithoutContext
{
    [SerializeField] private GameObject _currentLevel;
    [SerializeField] private BoxCollider _currentLevelCollider;
    
    public UnityEvent LastLevel;
    
    private StateMachine _stateMachine;
    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Exit()
    {
        RestartScene();
    }

    public void Enter()
    {
        LastLevel.Invoke();
    }
    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(GlobalConstants.SceneGame);
        _currentLevel.transform.localScale = new Vector3(35f, 35f, 0);
        _currentLevelCollider.size = new Vector3(5, 5, 0);
    }
   
}
