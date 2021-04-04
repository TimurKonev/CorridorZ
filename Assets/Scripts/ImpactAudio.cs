using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactAudio : MonoBehaviour
{
    [SerializeField] SimpleAudioEvent audioEvent;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();      
    }

    void Start()
    {
        GetComponent<Health>().OnTookHit += ImpactAudio_OnTookHit;
    }

    private void ImpactAudio_OnTookHit()
    {
        audioEvent.Play(audioSource);
    }

    
}
