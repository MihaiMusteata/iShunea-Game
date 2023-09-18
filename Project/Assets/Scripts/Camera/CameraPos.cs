﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraPos : MonoBehaviour
{
     public Transform target; 
     public float smoothSpeed = 5f;
     public Vector3 offset;
     void LateUpdate()
     {
          if (target == null)
               return;

          Vector3 desiredPosition = target.position + offset;

          Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

          transform.position = smoothedPosition;
          
     }
}