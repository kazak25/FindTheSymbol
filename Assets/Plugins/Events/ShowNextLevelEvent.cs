using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNextLevelEvent : MonoBehaviour
{
   public IEnumerator _showNextLevel { get; }

   public ShowNextLevelEvent(IEnumerator showNextLevel)
   {
      _showNextLevel = showNextLevel;
   }
}
