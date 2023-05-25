using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSO[] sounds;
    [SerializeField] private AudioClip[] backgroudMusics;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        SoundConfiguration();
    }
    private void OnEnable()
    {
        RewardManager.OnCoinSound += PlaySound;
        EnemyBase.OnEnemyGateDestroySound += PlaySound;
        SceneSwitcher.OnButtonClickSound += PlaySound;
        PlayerStickmanSpawner.OnBossStickManSound += PlaySound;
    }
    private void OnDisable()
    {
        RewardManager.OnCoinSound -= PlaySound;
        EnemyBase.OnEnemyGateDestroySound -= PlaySound;
        PlayerStickmanSpawner.OnBossStickManSound -= PlaySound;
        SceneSwitcher.OnButtonClickSound -= PlaySound;

    }
    private void Start()
    {
        PlayRandomBackgroundMusic();
    }
    private void PlayRandomBackgroundMusic()
    {
        AudioClip clip = backgroudMusics[UnityEngine.Random.Range(0, backgroudMusics.Length)];
        source.clip = clip;
        source.Play();
    }

    private void SoundConfiguration()
    {
        foreach (var sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.playOnAwake = sound.playOnAwake;
            sound.audioSource.loop = sound.loop;
        }
    }
    public void PlaySound(string soundName, bool state)
    {
        AudioSO audio = Array.Find(sounds, sound => sound.name == soundName);

        if (state)
        {
            if (audio == null)
                return;
            audio.audioSource.Play();
        }
        else
            audio.audioSource.Stop();

    }

}
