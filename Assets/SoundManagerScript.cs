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

    public bool _set = false;

    public Slider Volume;
    private float audioVolume;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDeath = Resources.Load<AudioClip> ("Audio/death");
        Jump = Resources.Load<AudioClip>("Audio/jump");
        GlassBreak = Resources.Load<AudioClip>("Audio/glass_break");

        audioSrc = GetComponent<AudioSource>();

    }

    void Awake()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_set)
        {
            AudioListener.volume = Volume.value;
            PlayerPrefs.SetFloat("MasterVolume", AudioListener.volume);
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
