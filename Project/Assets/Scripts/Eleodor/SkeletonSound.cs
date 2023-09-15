using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSound : MonoBehaviour
{
    public float footStepVolume = 0.1f;
    
    [SerializeField] private AudioClip[] footStepSounds = default;
    void footStep()
    {
        int randomIndex = Random.Range(0, footStepSounds.Length); // corectat de la footstepSounds.Lenght la footstepSounds.Length
        AudioManager.instance.source.volume = footStepVolume;
        AudioManager.instance.source.PlayOneShot(footStepSounds[randomIndex]);
    }
    
}
