using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsLoader : MonoBehaviour
{
    public AudioMixer mixer;
    // Start is called before the first frame update
    static bool loaded = false;
    public void loadSettings()
    {
        var sfx = PlayerPrefs.GetFloat("sfx", 0.0f);
        var music = PlayerPrefs.GetFloat("music", 0.0f);
        var master = PlayerPrefs.GetFloat("master", 0.0f);

        mixer.SetFloat("sfxVol", sfx);
        mixer.SetFloat("musicVol", music);
        mixer.SetFloat("masterVol", master);
        Board.mineProb = PlayerPrefs.GetFloat("mines", 0.1f);
        Board.gridSizeX = PlayerPrefs.GetInt("sx", 9);
        Board.gridSizeY = PlayerPrefs.GetInt("sy", 9);

    }
    void Start()
    {
        if (!loaded)
        {
            loadSettings();
        }
        loaded = true;

    }

}
