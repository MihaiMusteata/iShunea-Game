using System.Collections;
using UnityEngine;

public class ScaleTransition : MonoBehaviour
{
     [SerializeField] private float speed = 1.0f;
     [SerializeField] private Vector3 scaleTarget;
     [SerializeField] private GameObject objectTrigger;

     private Vector3 initialScale;
     private Vector3 finalScale;
     private bool isTransitioning = false;
     private float transitionStartTime;

     private void OnEnable()
     {
          initialScale = gameObject.transform.localScale;
          finalScale = scaleTarget;
     }
     private void Update()
     {
          if (objectTrigger.transform.position.y >= 6.4 && isTransitioning == false)
          {
               isTransitioning = true;
               transitionStartTime = Time.time;
          }

          if (isTransitioning)
          {
               float t = (Time.time - transitionStartTime) / speed;
               t = Mathf.Clamp01(t);
               gameObject.transform.localScale = Vector3.Lerp(initialScale, finalScale, t);


               if (t >= 1.0f)
               {
                    isTransitioning = false;
                    Destroy(gameObject.transform.parent.gameObject);
               }
          }
     }
}
