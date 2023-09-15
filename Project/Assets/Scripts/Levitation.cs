using UnityEngine;

public class Levitation : MonoBehaviour
{
     public float levitationDistance = 1.0f; 
     public float levitationSpeed = 1.0f; 
     public float rotationSpeed = 30.0f;
     public string rotationAxe = "Z";

     private Vector3 initialPosition;
     private Quaternion initialRotation;

     private void Start()
     {
          initialPosition = transform.position;
          initialRotation = transform.rotation;
     }

     private void Update()
     {
          float newY = initialPosition.y + Mathf.Sin(Time.time * levitationSpeed) * levitationDistance;
          transform.position = new Vector3(transform.position.x, newY, transform.position.z);
          switch(rotationAxe)
          {
               case "X":
                    transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
                    break;
               case "Y":
                    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                    break;
               case "Z":
                    transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                    break;
          }
     }
}