using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
   public GameObject myDialogue;
   
   public void ShowMyDialogue(GameObject oldDialogue)
   {
      if (oldDialogue)
      {
         oldDialogue.SetActive(false);
      }
      myDialogue.SetActive(true);
   }
}
