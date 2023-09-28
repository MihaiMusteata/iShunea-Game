using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetActive : MonoBehaviour
{
     [SerializeField] private GameObject objectTrigger;
     [SerializeField] private GameObject objectToActivate;

     private void Update()
     {
          if (objectTrigger == null)
          {
               objectToActivate.SetActive(true);
          }
     }
}
