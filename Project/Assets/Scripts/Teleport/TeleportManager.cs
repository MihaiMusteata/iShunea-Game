using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour
{
     [Header("Components")]
     [SerializeField] private List<string> sceneNames;

     public void SwitchToScene(int index)
     {
          SceneManager.LoadScene(sceneNames[index]);
     }
}
