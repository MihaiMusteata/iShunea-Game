using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class TeleportManager : MonoBehaviour
{
     [SerializeField] private GameObject player;
     public static TeleportManager instance;
     //PlayerController
     private ThirdPersonController playerController;
     private void Awake()
     {
          instance = this;
          playerController = player.GetComponent<ThirdPersonController>();

     }
     public void Teleport(Transform location)
     {
          StartCoroutine("TeleportCoroutine", location);
     }

     IEnumerator TeleportCoroutine(Transform location)
     {
          playerController.isTeleporting = true;
          yield return new WaitForSeconds(0.1f);
          player.transform.position = location.position;
          yield return new WaitForSeconds(0.1f);
          playerController.isTeleporting = false;
     }
}
