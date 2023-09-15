using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] attackSounds = default;
    void attack()
    {
        int randomIndex = Random.Range(0, attackSounds.Length); // corectat de la footstepSounds.Lenght la footstepSounds.Length

        AudioManager.instance.source.PlayOneShot(attackSounds[randomIndex]);
    }
}
