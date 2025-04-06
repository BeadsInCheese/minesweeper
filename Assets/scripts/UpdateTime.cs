using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTime : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;
    void Start()
    {
        text= GetComponent<TextMeshProUGUI>();
        twoDigitTimer timer = (twoDigitTimer)FindObjectOfType(typeof(twoDigitTimer));
        int s = (int)(timer.time % 60);
        int m = (int)(timer.time / 60 % 60);
        int h = (int)(timer.time / 3600);
        text.text="Solved in : "+h.ToString("00")+" : "+m.ToString("00")+" : "+s.ToString("00") ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
