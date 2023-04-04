using Settings;
using StateMachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace States
{
    public class GameOverState : MonoBehaviour,IStateWithoutContext
    {
        public UnityEvent LastLevel;
    
        [SerializeField] private GameObject _currentLevel;
        [SerializeField] private BoxCollider _currentLevelCollider;
    
        private StateMachine.StateMachine _stateMachine;
    
        public void Initialize(StateMachine.StateMachine stateMachine)
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
}
