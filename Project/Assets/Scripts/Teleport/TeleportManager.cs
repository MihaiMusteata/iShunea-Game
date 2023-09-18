using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour
{
     [Header("Components")]
     [SerializeField] private List<string> sceneNames;
     public static TeleportManager instance;

     private void Awake()
     {
          instance = this;
     }
     public void SwitchToScene(string sceneName)
     {
          SceneManager.LoadScene(sceneName);
     }
}
