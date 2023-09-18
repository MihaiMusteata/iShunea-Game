using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFollowCamera : MonoBehaviour
{
     [SerializeField] private GameObject target;

     private void Update()
     {
          Vector3 directionToCamera = target.transform.position - transform.position;

          Quaternion rotationToCamera = Quaternion.LookRotation(directionToCamera);

          transform.rotation = rotationToCamera;
     }
}
