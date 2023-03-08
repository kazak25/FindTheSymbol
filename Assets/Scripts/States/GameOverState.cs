using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : MonoBehaviour,IStateWithoutContext
{
    public void Initialize(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }
    
    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(GlobalConstants.SceneGame);
    }
}
