using UnityEngine;

public class CameraTransition : MonoBehaviour
{
     [SerializeField] private Camera mainCamera;
     [SerializeField] private GameObject camPos;
     public Quaternion mainCameraTarget;
     public Vector3 camPosTarget;
     public float smoothSpeed = 5f;

     private Quaternion mainCameraInitialRotation;
     private Vector3 camPosInitialOffset;
     private bool isTransitioning = false;
     private bool reverse = false;
     private float transitionStartTime;

     private void Start()
     {
          mainCameraInitialRotation = mainCamera.transform.rotation;
          camPosInitialOffset = camPos.transform.position;
     }

     private void Update()
     {
          if (isTransitioning)
          {
               float t = (Time.time - transitionStartTime) / smoothSpeed;
               t = Mathf.Clamp01(t);
               if (!reverse)
               {
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCameraInitialRotation, mainCameraTarget, t);
                    camPos.transform.position = Vector3.Lerp(camPosInitialOffset, camPosTarget, t);
               }
               else
               {
                    mainCamera.transform.rotation = Quaternion.Slerp(mainCameraTarget, mainCameraInitialRotation, t);
                    camPos.transform.position = Vector3.Lerp(camPosTarget, camPosInitialOffset, t);

               }

               if (t >= 1.0f)
               {
                    isTransitioning = false;
               }
          }
     }

     private void StartTransition()
     {
          if (!isTransitioning)
          {
               isTransitioning = true;
               transitionStartTime = Time.time;
               reverse = false;
          }
     }

     private void ReversTransition()
     {
          if (!isTransitioning)
          {
               isTransitioning = true;
               transitionStartTime = Time.time;
               reverse = true;
          }
     }


     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag("Player"))
          {
               isTransitioning = false;
               StartTransition();
          }
     }

     private void OnTriggerExit(Collider other)
     {
          if (other.CompareTag("Player"))
          {
               isTransitioning = false;
               ReversTransition();
          }
     }
}
