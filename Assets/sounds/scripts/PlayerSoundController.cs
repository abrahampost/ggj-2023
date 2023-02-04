using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip footstep;

    [SerializeField]
    private AudioSource audioSource;

    private bool isPlaying;

    private void Start()
    {
        audioSource.clip = footstep;
    }

    private IEnumerator playInDelayedLoop(float delay)
    {
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
}