using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkWithWizard : MonoBehaviour
{
     [SerializeField] private GameObject listOfStories;

     public void OpenStory(int index)
     {
          listOfStories.transform.GetChild(index).gameObject.SetActive(true);
     }
}
