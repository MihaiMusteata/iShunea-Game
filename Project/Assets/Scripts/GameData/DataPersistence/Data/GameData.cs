using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData
{
     public long lastUpdated;
     public Vector3 playerPosition;
     public SerializableDictionary<string, bool> gemsCollected;
     public SerializableDictionary<string, bool> coinsCollected;
     public AttributesData playerAttributesData;
     public bool isTutorialCompleted = false;
     public int currentLevel;
     public int currentExperience;
     public int currentGold;
     public string lastUpdate;
     public bool gameOver = false;
     public int currentHP;


     // the values defined in this constructor will be the default values
     // the game starts with when there's no data to load
     public GameData()
     {
          playerPosition = new Vector3(-31, 6, 56);
          gemsCollected = new SerializableDictionary<string, bool>();
          coinsCollected = new SerializableDictionary<string, bool>();
          playerAttributesData = new AttributesData();
     }

}
