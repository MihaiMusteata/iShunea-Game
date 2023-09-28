using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeText : MonoBehaviour
{
     [SerializeField] private TextMeshProUGUI textField;
     [SerializeField] private GameObject button;
     [SerializeField] private float typingSpeed = 0.1f;
     private string textToType;

     private bool isTyping = false;

     public void OnEnable()
     {
          button.SetActive(false);
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

          button.SetActive(true);

     }
}
