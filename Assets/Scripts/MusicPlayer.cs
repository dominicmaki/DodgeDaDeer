using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource backgroundMusicSource; // Reference for background music
    public AudioSource sfxSource;              // Reference for sound effects
    public AudioClip backgroundMusic;          // Background music clip
    public AudioClip collisionSound;           // Collision sound effect clip
    // Start is called before the first frame update
    void Start()
    {
          // Play background music at the start
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true; // Loop the background music
        backgroundMusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayCollisionSound()
    {
        sfxSource.PlayOneShot(collisionSound); // Play collision sound effect
    }
}
