/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraPos : MonoBehaviour
{
     [SerializeField] private GameObject camPos;

     public Transform target; 
     public float smoothSpeed = 5f;
     public Vector3 offset;
     private void Start()
     {
          offset = camPos.transform.position;
     }
     void LateUpdate()
     {
          if (target == null)
               return;
          offset = camPos.transform.position;

          Vector3 desiredPosition = target.position + offset;

          Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

          transform.position = smoothedPosition;
          
     }
} */
/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] private GameObject camPos;

    public Transform target;
    public float smoothSpeed = 5f;
    public float rotationSpeed = 2.0f; // Viteza de rotație a camerei
    public Vector3 offset;

     private void Start()
     {
          offset = transform.position - target.position; // Calculăm offset-ul corect în funcție de poziția camerei și a jucătorului în momentul inițial.
     }

    void LateUpdate()
    {
        if (target == null)
            return;

        // Obțineți mișcarea mouse-ului pe axele X și Y
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Rotați camera în jurul obiectului țintă pe baza mișcării mouse-ului
        Quaternion camTurnAngleX = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion camTurnAngleY = Quaternion.AngleAxis(-mouseY, Vector3.right);

        offset = camTurnAngleX * camTurnAngleY * offset;

        Vector3 desiredPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        transform.LookAt(target); // Camera se uită întotdeauna spre jucător
    }
}
 */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 2.0f;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    public Vector3 offset;

    [SerializeField] private GameObject camPos;

     public float smoothSpeed = 5f;
     private void Start()
     {
          offset = camPos.transform.position;
     }
    private void Update()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                touchEndPos = touch.position;
                Vector2 touchDelta = touchEndPos - touchStartPos;

                // Rotați camera pe baza mișcării degetului
                float rotationX = touchDelta.x * rotationSpeed * Time.deltaTime;
                float rotationY = -touchDelta.y * rotationSpeed * Time.deltaTime;

                transform.RotateAround(target.position, Vector3.up, rotationX);
                transform.RotateAround(target.position, transform.right, rotationY);

                // Actualizați poziția de început pentru următoarea iterație
                touchStartPos = touch.position;
            }
        }
    }
}
