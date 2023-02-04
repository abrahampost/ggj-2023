using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip footstep;

    [SerializeField]
    private AudioSource audioSource;

    public void PlayFootStepsIfMoving(Vector2 velocity)
    {
        if (velocity.magnitude > 0 && !audioSource.isPlaying)
        {
            audioSource.clip = footstep;
            audioSource.Play();
        }
        else if (velocity.magnitude == 0 && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}