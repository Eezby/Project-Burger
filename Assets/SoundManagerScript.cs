using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip PlayerDeath,Jump,GlassBreak;
    static AudioSource audioSrc;
    public AudioSource Music;

    public Slider Volume;
    private float audioVolume;


    // Start is called before the first frame update
    void Start()
    {
        Music.volume = PlayerPrefs.GetFloat("MasterVolume");

        PlayerDeath = Resources.Load<AudioClip> ("Audio/death");
        Jump = Resources.Load<AudioClip>("Audio/jump");
        GlassBreak = Resources.Load<AudioClip>("Audio/glass_break");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Music.volume == 1)
        {
            Music.volume = Volume.value;
            PlayerPrefs.SetFloat("MasterVolume", Music.volume);
        }
        else
        {
            Music.volume = PlayerPrefs.GetFloat("MasterVolume");
        }
        
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "death":
                audioSrc.PlayOneShot(PlayerDeath);
                break;

            case "glass":
                audioSrc.PlayOneShot(GlassBreak);
                break;

            case "jump":
                audioSrc.PlayOneShot(Jump);
                break;
        }
    }
}
