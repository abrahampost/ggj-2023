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



    public void PlayProjectileLaunch()
    {
        audioSource.clip = projectileLaunch;
        audioSource.Play();
    }
}
