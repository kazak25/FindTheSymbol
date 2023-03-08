using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public UnityEvent PlayMode;
  
  [SerializeField] private GameState _gameState;
  
  [SerializeField] private Canvas _startScreen;
  [SerializeField] private Canvas _standartScreen;
  
  [SerializeField] private BoxCollider _currentLevelCollider;
  
  [SerializeField] private CellController cellController;
  
  [SerializeField] public GameObject _nextLevelbutton;
  [SerializeField] public GameObject _restartButton;
  [SerializeField] private GameObject _currentLevel;
  
  [SerializeField] private AudioSource _win;
  [SerializeField] private AudioSource _fail;

  [UsedImplicitly]
  public void StandartSprites()
  {
    _startScreen.enabled = false;
    _standartScreen.enabled = true;
  }
  
  [UsedImplicitly]
  public void ChildrenDelete(GameObject gameObject)
  {
    var temp = gameObject.transform;

    foreach (Transform child in temp)
    {
      Destroy(child.gameObject);
    }
  }
  
  public void RightSelection(Transform localScale, SpriteRenderer spriteRenderer, GameObject cell)
  {
    _win.Play();
    _gameState.WinConditionOn();
    var scale =localScale.transform.localScale;
    cellController.ShowIcon(spriteRenderer,_gameState.isWinCondition);
    cellController.ScaleEffect(cell,scale);
    _gameState.ChangeLevelNumber();
  }

  public void WrongSelection(SpriteRenderer spriteRenderer)
  {
    _fail.Play();
    cellController.ShowIcon(spriteRenderer,_gameState.isWinCondition);
  }
  
  [UsedImplicitly]
  public void RestartScene()
  {
    SceneManager.LoadSceneAsync(GlobalConstants.SceneGame);
    _currentLevel.transform.localScale = new Vector3(35f, 35f, 0);
    _currentLevelCollider.size = new Vector3(5, 5, 0);
  }
}
  
