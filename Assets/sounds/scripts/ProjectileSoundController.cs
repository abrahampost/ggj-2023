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
    private AudioSource audioSourceLaunch;

    private void Start()
    {
        audioSourceLaunch.clip = projectileLaunch;
    }

    public void PlayProjectileLaunch()
    {
        audioSourceLaunch.Play();
    }
}
