using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip treeGrowth;

    [SerializeField]
    private AudioClip ambientTreeSound;

    [SerializeField]
    private AudioSource treeGrowthSource;

    [SerializeField]
    private AudioSource ambientTreeSoundSource;

    private float basePitch = 1.4f;

    private void Start()
    {
        ambientTreeSoundSource.clip = ambientTreeSound;
        ambientTreeSoundSource.pitch = basePitch;
        ambientTreeSoundSource.Play();
    }

    public void PlayTreeGrowth()
    {
        treeGrowthSource.clip = treeGrowth;
        treeGrowthSource.Play();
    }
    
    public void DecreaseAmbientSoundPitch(float value)
    {
        ambientTreeSoundSource.pitch -= value;
    }

    public void IncreaseAmbientSoundPitch(float value)
    {
        ambientTreeSoundSource.pitch += value;
    }

    public float GetPitch()
    {
        return ambientTreeSoundSource.pitch;
    }
}
