using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioManager instance;

    public AudioSource sfx;
    public AudioSource music;
    public AudioClip navSound;
    public AudioClip tileSound;
    void Awake()
    {
        
        if (instance != null) {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void playSFX(AudioClip audio)
    {

        sfx.PlayOneShot(audio);
    }
    public void PlayNavSound()
    {
        playSFX(navSound);

    }
    public void PlayTileSound()
    {

        playSFX(tileSound);
    }
    public void playMusic(AudioClip audio)
    {
        if (audio == music.clip) {
            return;
        }
        music.clip = audio;
        music.loop = true;
        music.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
