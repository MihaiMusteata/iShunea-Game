using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeText : MonoBehaviour
{
     [SerializeField] private TextMeshProUGUI textField;
     private string textToType;
     public float typingSpeed = 0.1f;

     private bool isTyping = false;

     public void GoType()
     {
          Debug.Log("A");
          textToType = textField.text;
          textField.text = "";
          StartCoroutine(Type());

     }

     IEnumerator Type()
     {
          isTyping = true;
          textField.enabled = true;
          for (int i = 0; i < textToType.Length; i++)
          {
               textField.text += textToType[i];
               yield return new WaitForSeconds(typingSpeed);
          }
     }
}
