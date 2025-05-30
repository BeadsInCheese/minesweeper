using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settingsPrefab;
    public AudioClip navigationButtonSound;
    public void SubMenuBack()
    {
        AudioManager.instance.PlayNavSound();
        GameObject.FindFirstObjectByType<mainMenuActivator>().activate();
        Destroy(gameObject);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void spawnSettings()
    {
        AudioManager.instance.PlayNavSound();
        var nav=Instantiate(settingsPrefab);

    }
   
    public void loadGame()
    {
        AudioManager.instance.PlayNavSound();
        StartCoroutine(FadeController.instance.changeSceneWithTransition("Game"));

    }
    public void loadMainMenu()
    {
        AudioManager.instance.PlayNavSound();
        StartCoroutine(FadeController.instance.changeSceneWithTransition("MainMenu"));
    }
}
