using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public TMPro.TextMeshProUGUI hText;
    public TMPro.TextMeshProUGUI wText;
    public TMPro.TextMeshProUGUI rateText;
    // Start is called before the first frame update
    public Slider mineRate;
    public Slider gridHeight;
    public Slider gridWidth;


    public Slider sfxSlider;
    public Slider masterSlider;
    public Slider musicSlider;

    public AudioMixer mixer;



    public IEnumerator debouncePlaysound(float timeout)
    {
        
        float timer = 0;
        while (timer < timeout) {
            timer+= Time.deltaTime;
            yield return 0; 
        }
        AudioManager.instance.PlayNavSound();
    }
    Coroutine debouncesound;
    void Start()
    {
        mineRate.minValue = 0.1f;
        mineRate.maxValue = 0.8f;
        mineRate.value=Board.mineProb;
        rateText.text = System.Math.Round(Board.mineProb*100, 2) + "%";
        mineRate.onValueChanged.AddListener((float val) => {PlayerPrefs.SetFloat("mines",val); Board.mineProb = val; rateText.text = System.Math.Round(val * 100, 2) + "%"; });
        gridHeight.maxValue = 18;
        gridWidth.maxValue = 18;
        gridHeight.minValue = 5;
        gridWidth.minValue = 5;
        gridWidth.wholeNumbers = true;
        gridHeight.wholeNumbers = true;
        gridHeight.value = Board.gridSizeY;
        gridWidth.value = Board.gridSizeX;
        hText.text = Board.gridSizeY + "";
        wText.text = Board.gridSizeX + "";
        gridWidth.onValueChanged.AddListener((float val) => { PlayerPrefs.SetInt("sx", (int)val);  Board.gridSizeX = (int)val;wText.text = val + ""; });
        gridHeight.onValueChanged.AddListener((float val) => { PlayerPrefs.SetInt("sy", (int)val); Board.gridSizeY = (int)val; hText.text = val + ""; });

        sfxSlider.maxValue = 20;
        masterSlider.maxValue = 20;
        musicSlider.maxValue = 20;

        sfxSlider.minValue = -80;
        masterSlider.minValue = -80;
        musicSlider.minValue = -80;
        float temp;
         mixer.GetFloat("sfxVol",out temp);
        sfxSlider.value = temp;
        mixer.GetFloat("musicVol", out temp);
        musicSlider.value = temp;
        mixer.GetFloat("masterVol", out temp);
        masterSlider.value = temp;

        sfxSlider.onValueChanged.AddListener((float val) => {PlayerPrefs.SetFloat("sfx", val); mixer.SetFloat("sfxVol", val); 
            if (debouncesound != null)
            {
                StopCoroutine(debouncesound);
                
            }
            debouncesound = StartCoroutine(debouncePlaysound(0.3f));
            
        });
        
        musicSlider.onValueChanged.AddListener((float val) => { PlayerPrefs.SetFloat("music", val); mixer.SetFloat("musicVol", val); });
        masterSlider.onValueChanged.AddListener((float val) => { PlayerPrefs.SetFloat("master", val); mixer.SetFloat("masterVol", val); });

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
