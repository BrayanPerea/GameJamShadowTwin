using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour

{
    public AudioClip[] sounds;
    private AudioSource source;
    [Range(0.1f,0.5f)]
    public float volumeChangeMultiplier = 0.2f;
    [Range(0.1f, 0.5f)]
    public float pitchChangeMultiplier = 0.2f;

     //Timer
    public float timer = 5.0f;
    public float minTime;
    public float maxTime;
    


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        
    
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
       
           //Sounds
       
        if(timer <= 0)
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.volume = Random.Range(1 - volumeChangeMultiplier, 1);
            source.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
            source.PlayOneShot(source.clip);
            timer = Random.Range(minTime, maxTime);
        }
    }
}
