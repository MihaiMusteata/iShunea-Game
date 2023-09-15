using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
     [Header("Components")]
     [SerializeField] private Image hpSlider;
     [SerializeField] private TextMeshProUGUI hpText;
     [SerializeField] private float reduceSpeed = 2;

     private float target ;
     private void OnEnable()
     {
          GameEventsManager.instance.playerEvents.onPlayerHealthChange += PlayerHealthChange;
     }

     private void OnDisable()
     {
          GameEventsManager.instance.playerEvents.onPlayerHealthChange -= PlayerHealthChange;
     }

     private void PlayerHealthChange(int health)
     {
          target = (float)health / GlobalConstants.maxHP;
     }

     private void Update()
     {
          hpSlider.fillAmount = Mathf.MoveTowards(hpSlider.fillAmount, target, Time.deltaTime * reduceSpeed);
          hpText.text = Mathf.Round(hpSlider.fillAmount * GlobalConstants.maxHP) + " / " + GlobalConstants.maxHP;
     }

}
