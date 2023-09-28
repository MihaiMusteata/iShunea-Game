using UnityEngine;
using System.Collections;

public class SummonPortal : MonoBehaviour
{
     [SerializeField] private float speed = 1.0f;
     [SerializeField] private float yTarget;
     [SerializeField] private GameObject portal;

     private Vector3 initialPosition;
     private Vector3 finalPosition;
     private bool isTransitioning = true;
     private float transitionStartTime;

     private void OnEnable()
     {
          initialPosition = portal.transform.position;
          finalPosition = new Vector3(portal.transform.position.x, yTarget, portal.transform.position.z);
          transitionStartTime = Time.time;
     }

     private void Update()
     {
          if (isTransitioning)
          {
               float t = (Time.time - transitionStartTime) / speed;
               t = Mathf.Clamp01(t);
               portal.transform.position = Vector3.Lerp(initialPosition, finalPosition, t);


               if (t >= 1.0f)
               {
                    isTransitioning = false;
               }
          }
     }

}
