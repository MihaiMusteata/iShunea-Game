using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAlternation : MonoBehaviour
{
     public Light lumina;           
     public float durataCiclului = 2.0f;   

     public Color culoareInitiala;
     public Color culoareFinala;
     private float timpTrecut = 0.0f;

     void Update()
     {
          timpTrecut += Time.deltaTime;
          float progres = Mathf.Clamp01(timpTrecut / durataCiclului);

          lumina.color = Color.Lerp(culoareInitiala, culoareFinala, progres);

          if (progres >= 1.0f)
          {
               timpTrecut = 0.0f;
               Color temp = culoareInitiala;
               culoareInitiala = culoareFinala;
               culoareFinala = temp;
          }
     }
}
