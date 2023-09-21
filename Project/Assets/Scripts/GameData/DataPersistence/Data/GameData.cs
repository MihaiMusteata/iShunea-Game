using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
     public long lastUpdated;
     public Vector3 playerPosition;
     public SerializableDictionary<string, bool> gemsCollected;
     public SerializableDictionary<string, bool> coinsCollected;
     public AttributesData playerAttributesData;
     public int currentLevel;
     public int currentExperience;
     public int currentGold;


     // the values defined in this constructor will be the default values
     // the game starts with when there's no data to load
     public GameData()
     {
          playerPosition = new Vector3(4, 3, 7);
          gemsCollected = new SerializableDictionary<string, bool>();
          coinsCollected = new SerializableDictionary<string, bool>();
          playerAttributesData = new AttributesData();
     }

}
