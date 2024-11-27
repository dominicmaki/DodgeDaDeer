using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SFXPlayer
{
    public static void PlaySound(AudioClip clip)
    {
        if (clip == null)
            Debug.LogError("ERROR: Clip empty!");

        GameObject playerObject = new("AudioPlayer");
        AudioSource source = playerObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        GameObject.Destroy(playerObject, clip.length);
    }
}
