using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip PlayerDeath,BulletSound,Jump,GlassBreak;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDeath = Resources.Load<AudioClip> ("Audio/death");
        //BulletSound = Resources.Load<AudioClip>("death_scream");
        Jump = Resources.Load<AudioClip>("Audio/jump");
        GlassBreak = Resources.Load<AudioClip>("Audio/glass_break");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip){
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
