using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ProjectileSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip melee;

    [SerializeField]
    private AudioClip projectileLaunch;

    [SerializeField]
    private AudioClip projectileImpact;

    [SerializeField]
    private AudioSource audioSource;

    public void PlayProjectileImpact()
    {
        audioSource.clip = projectileImpact;
        audioSource.Play();
    }
}
