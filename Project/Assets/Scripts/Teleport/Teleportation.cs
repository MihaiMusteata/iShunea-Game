using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
     [Header("Destination")]
     [SerializeField] private string sceneName;

     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag("Player"))
          {
               TeleportManager.instance.SwitchToScene(sceneName);
          }
     }
}
