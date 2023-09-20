using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSound : MonoBehaviour
{
    public float footStepVolume = 0.1f;
    public float AttackVolume = 0.1f;
    
    [SerializeField] private AudioClip[] footStepSounds = default;
    void footStep()
    {
        int randomIndex = Random.Range(0, footStepSounds.Length); // corectat de la footstepSounds.Lenght la footstepSounds.Length
        AudioManager.instance.source.volume = footStepVolume;
        AudioManager.instance.source.PlayOneShot(footStepSounds[randomIndex]);
    }
    [SerializeField] private AudioClip[] AttackSounds = default;
    void SkeletAttack()
    {
        int randomIndex = Random.Range(0, footStepSounds.Length); // corectat de la footstepSounds.Lenght la footstepSounds.Length
        AudioManager.instance.source.volume = AttackVolume;
        AudioManager.instance.source.PlayOneShot(AttackSounds[randomIndex]);

    }
    
}
