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

    public void PlayProjectileLaunch(float cooldown)
    {
        audioSource.clip = projectileLaunch;
        audioSource.Play();
        Task.Delay(TimeSpan.FromSeconds(cooldown)).ContinueWith((_task) => audioSource.Stop());
    }
}
