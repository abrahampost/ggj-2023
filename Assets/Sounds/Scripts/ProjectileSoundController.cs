using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip projectileLaunch;

    [SerializeField]
    private AudioClip meleeAttack;

    [SerializeField]
    private AudioSource audioSourceLaunch;

    public void PlayProjectileLaunch()
    {
        audioSourceLaunch.clip = projectileLaunch;
        audioSourceLaunch.Play();
    }

    public void PlayMeleeAttack()
    {
        audioSourceLaunch.clip = meleeAttack;
        audioSourceLaunch.Play();
    }
}
