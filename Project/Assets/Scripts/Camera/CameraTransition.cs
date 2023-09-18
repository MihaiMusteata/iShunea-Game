using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
     [SerializeField] private Transform targetPosition;
     [SerializeField] private float transitionDuration = 2.0f; 

     private Camera mainCamera;
     private Vector3 initialCameraPosition;
     private float transitionStartTime;
     private bool isTransitioning = false;

     private void Start()
     {
          mainCamera = Camera.main;
          initialCameraPosition = mainCamera.transform.position;
     }

     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag("Player") && !isTransitioning)
          {
               StartTransition();
          }
     }

     private void OnTriggerExit(Collider other)
     {
          if (other.CompareTag("Player") && !isTransitioning)
          {
               StartTransition();
          }
     }

     private void StartTransition()
     {
          transitionStartTime = Time.time;
          isTransitioning = true;
     }

     private void Update()
     {
          if (isTransitioning)
          {
               float t = (Time.time - transitionStartTime) / transitionDuration;
               t = Mathf.Clamp01(t);

               mainCamera.transform.position = Vector3.Lerp(
                   initialCameraPosition, targetPosition.position, t);
               1
               if (t >= 1.0f)
               {
                    isTransitioning = false;
               }
          }
     }
}
