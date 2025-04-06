using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip musicClip;
    void Start()
    {
        AudioManager.instance.playMusic(musicClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
