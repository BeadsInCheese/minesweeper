using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class twoDigitTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool running = true;
    public Image digit1;
    public Image digit2;

    public Image digit3;
    public Image digit4;

    public Image digit5;
    public Image digit6;
    public float time = 0;
    public AudioClip digitSound;
    private float updateTimer=0;
    void Start()
    {
        digit1.material = new Material(digit1.material);
        digit2.material = new Material(digit2.material);
        digit3.material = new Material(digit3.material);
        digit4.material = new Material(digit4.material);
        digit5.material = new Material(digit5.material);
        digit6.material = new Material(digit6.material);
        digit1.material.SetInteger("_Row", 2);
        digit2.material.SetInteger("_Row", 2);
        digit3.material.SetInteger("_Row", 2);
        digit4.material.SetInteger("_Row", 2);
        digit5.material.SetInteger("_Row", 2);
        digit6.material.SetInteger("_Row", 2);
    }
    public void SecondPassed()
    {
        (int, int) valsec = DigitUtil.extract2Digits((int)(time % 60));
        digit1.material.SetInteger("_Digit1", valsec.Item1);
        digit2.material.SetInteger("_Digit1", valsec.Item2);
        (int, int) valsmin = DigitUtil.extract2Digits((int)((time / 60) % 60));
        digit3.material.SetInteger("_Digit1", valsmin.Item1);
        digit4.material.SetInteger("_Digit1", valsmin.Item2);
        (int, int) valshour = DigitUtil.extract2Digits((int)((time / 3600)));
        digit5.material.SetInteger("_Digit1", valshour.Item1);
        digit6.material.SetInteger("_Digit1", valshour.Item2);
        AudioManager.instance.playSFX(digitSound);


    }
    public void stopTimer()
    {
        running = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            time = time += Time.deltaTime;
            updateTimer += Time.deltaTime;
            if (updateTimer >= 1)
            {
                SecondPassed();
                updateTimer = 0;
            }
        }
    }
}
