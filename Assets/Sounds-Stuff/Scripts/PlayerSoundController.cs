using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip footstep;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip deathScream;

    [SerializeField]
    private AudioClip onHitSound;

    private bool isPlaying;

    private IEnumerator playInDelayedLoop(float delay)
    {
        audioSource.clip = footstep;
        audioSource.Play();
        yield return new WaitForSeconds(delay);
        isPlaying = false;
    }

    public void PlayFootStepsIfMoving(Vector2 velocity)
    {
        if (velocity.magnitude > 0 && !isPlaying)
        {
            isPlaying = true;
            StartCoroutine(playInDelayedLoop(0.25f));
        }
    }

    public void playDeathScream()
    {
        audioSource.clip = deathScream;
        audioSource.Play();
    }

    public void playOnHit()
    {
        audioSource.clip = onHitSound;
        audioSource.Play();
    }
}