using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuActivator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject start;
    public GameObject settings;
    public GameObject quit;
    public void activate()
    {
        start.SetActive(true);
        settings.SetActive(true);
        quit.SetActive(true);
    }
    public void deactivate()
    {
        start.SetActive(false);
        settings.SetActive(false);
        quit.SetActive(false);
    }

}
