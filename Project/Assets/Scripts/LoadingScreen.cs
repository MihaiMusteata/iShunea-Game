using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
     [SerializeField] private Image slider;
     [SerializeField] private Text loadingText;
     [SerializeField] private float loadingSpeed = 0.1f;

     public float fadeDuration = 1.0f;

     private CanvasGroup canvasGroup;



     private void Awake()
     {
          slider.fillAmount = 0f;
          canvasGroup = GetComponent<CanvasGroup>();
          canvasGroup.alpha = 1f;
     }

     private void OnEnable()
     {
          slider.fillAmount = 0f;
          canvasGroup.alpha = 1f;
          LoadScreen();
     }
     
     private void OnDisable()
     {
          slider.fillAmount = 0f;
          canvasGroup.alpha = 1f;
     }
     

     public void LoadScreen()
     {
          StartCoroutine(LoadScreenAsync());
     }

     IEnumerator LoadScreenAsync()
     {
          float progress = 0f;
          while (progress < 1f)
          {
               if (slider.fillAmount < 1f)
               {
                    slider.fillAmount += loadingSpeed * Time.deltaTime;
                    loadingText.text = (slider.fillAmount * 100).ToString("F0") + "%";
                    progress = slider.fillAmount;
               }
               else
               {
                    loadingText.text = "Loading Complete";
                    break;
               }
               yield return null;
          }

          StartCoroutine(FadeOut());
     }



     private IEnumerator FadeOut()
     {
          float startAlpha = canvasGroup.alpha;
          float elapsedTime = 0f;

          while (elapsedTime < fadeDuration)
          {
               float newAlpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);
               canvasGroup.alpha = newAlpha;

               elapsedTime += Time.deltaTime;
               yield return null;
          }

          gameObject.SetActive(false);
          canvasGroup.alpha = 0f;
     }



}
