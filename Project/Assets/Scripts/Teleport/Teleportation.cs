using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
     [Header("Maps")]
     [SerializeField] private GameObject currentMap;
     [SerializeField] private GameObject destinationMap;
     [Header("Destination")]
     [SerializeField] private Transform location;


     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag("Player"))
          {
               currentMap.SetActive(false);
               TeleportManager.instance.Teleport(location);
               destinationMap.SetActive(true);
          }
     }
}
