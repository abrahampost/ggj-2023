using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class AttackSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip fireballLaunch;

    [SerializeField]
    private AudioClip playerMeleeAttack;

    [SerializeField]
    private AudioClip skellyMeleeAttack;

    [SerializeField]
    private AudioClip coneOfColdAtack;

    [SerializeField]
    private AudioClip placeThorns;

    [SerializeField]
    private AudioSource fireballLaunchSource;

    [SerializeField]
    private AudioSource playerMeleeAttackSource;

    [SerializeField]
    private AudioSource skellyMeleeAttackSource;

    [SerializeField]
    private AudioSource coneOfColdAtackSource;

    [SerializeField]
    private AudioSource placeThornsSource;

    private void Start()
    {
        fireballLaunchSource.clip = fireballLaunch;
        playerMeleeAttackSource.clip = playerMeleeAttack;
        skellyMeleeAttackSource.clip = skellyMeleeAttack;
        coneOfColdAtackSource.clip = coneOfColdAtack;
        placeThornsSource.clip = placeThorns;
    }

    public void FireballLaunch()
    {
        fireballLaunchSource.Play();
    }

    public void PlayerMeleeAttack()
    {
        playerMeleeAttackSource.Play();
    }

    public void SkellyMeleeAttack()
    {
        skellyMeleeAttackSource.Play();
    }

    public void ConeOfColdAttack()
    {
        coneOfColdAtackSource.Play();
    }

    public void PlaceThorns()
    {
        placeThornsSource.Play();
    }
}
