using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
    STEPS,
    JUMP,
    LANDING,
    HURT,
    GAMEOVER,
    GAMEWIN,
    UI
}

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] soundList;
    
    private void Awake() 
    {
        instance = this;   

        DontDestroyOnLoad(this); 
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }
}

