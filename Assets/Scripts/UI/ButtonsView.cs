using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonsView : MonoBehaviour
{
    [SerializeField] public GameObject _nextLevelbutton;
    [SerializeField] public GameObject _restartButton;


    public void NextLevelCorutine()
    {
        StartCoroutine(ShowButtonNextLevel());
    }

    public void RestartCorutine()
    {
        StartCoroutine(ShowButtonRestart());
    }
    
   IEnumerator ShowButtonNextLevel()   //перенести в скрипт для  UI элементов
    {
        yield return new WaitForSeconds(2);
        _nextLevelbutton.SetActive(true);
    }
    IEnumerator ShowButtonRestart()
    {
        yield return new WaitForSeconds(2);
        _restartButton.SetActive(true);
    }
}
