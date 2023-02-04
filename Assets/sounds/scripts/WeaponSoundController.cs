using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip projectileLaunch;

    [SerializeField]
    private AudioSource audioSource;

    private IEnumerator coroutine;

    private IEnumerator StopPlayingAfterCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        audioSource.Stop();
    }

    public void PlayProjectileLaunch(float cooldown)
    {
        audioSource.clip = projectileLaunch;
        audioSource.Play();

        coroutine = StopPlayingAfterCooldown(cooldown);
        StartCoroutine(coroutine);
    }
}
