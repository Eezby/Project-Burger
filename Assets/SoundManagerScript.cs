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
    private float audioVolume = 1f;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDeath = Resources.Load<AudioClip> ("Audio/death");
        Jump = Resources.Load<AudioClip>("Audio/jump");
        GlassBreak = Resources.Load<AudioClip>("Audio/glass_break");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Music.volume = Volume.value;
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
    public void SetVolume(float vol)
    {
        audioVolume = vol;
        PlayerPrefs.SetFloat("MasterVolume", audioVolume);
    }
}
