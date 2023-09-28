using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuestStep : QuestStep
{
     private void Update()
     {
          Debug.Log("Tutorial taken");
          CheckTutorialState();
     }
     private void CheckTutorialState()
     {
          if(GameEventsManager.instance.isTutorialCompleted)
          {
               FinishQuestStep();
               Debug.Log("Tutorial Completed");
          }
     }
     protected override void SetQuestStepState(string state)
     {
     }
}
