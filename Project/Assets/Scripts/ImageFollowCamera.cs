using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFollowCamera : MonoBehaviour
{
     private Camera mainCamera;

     private void Start()
     {
          mainCamera = Camera.main;
     }

     private void Update()
     {
          Vector3 directionToCamera = mainCamera.transform.position - transform.position;

          Quaternion rotationToCamera = Quaternion.LookRotation(directionToCamera);

          transform.rotation = rotationToCamera;
     }
}
