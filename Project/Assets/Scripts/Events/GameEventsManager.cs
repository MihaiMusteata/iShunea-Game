using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
     public static GameEventsManager instance { get; private set; }

     public InputEvents inputEvents;
     public PlayerEvents playerEvents;
     public GoldEvents goldEvents;
     public MiscEvents miscEvents;
     public QuestEvents questEvents;

     public bool isTutorialCompleted = false;

     private void Awake()
     {
          if (instance != null)
          {
               Debug.LogError("Found more than one Game Events Manager in the scene.");
          }
          instance = this;

          // initialize all events
          inputEvents = new InputEvents();
          playerEvents = new PlayerEvents();
          goldEvents = new GoldEvents();
          miscEvents = new MiscEvents();
          questEvents = new QuestEvents();
     }

     public void CompleteTutorial()
     {
          this.isTutorialCompleted = true;
          Debug.Log("Completed");
     }
}
