using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(AudioSource))]

public class WeaponSound : WeaponComponent
{
    [SerializeField] SimpleAudioEvent audioEvent;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    protected override void WeaponFired()
    {
        audioEvent.Play(audioSource);
    }
}
