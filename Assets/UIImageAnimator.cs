using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIImageAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    Image img;
    public int fps;
    private float time;
    private bool isPlaying = false;
    public bool loop = false;
    private float frameTimeDelta;
    public UnityEvent timeOut;
    private int framePointer = 0;
    public List<Sprite> frames;
    void Start()
    {
        img= GetComponent<Image>();
        frameTimeDelta = 1.0f / fps;
        //StartCoroutine(animate());
    }
    public void playAnim()
    {
        StartCoroutine(animate());
    }
    IEnumerator animate()
    {
        isPlaying = true;
        while (true)
        {
            if (!isPlaying) { 
            break;
            }
            if (time > frameTimeDelta)
            {
                time = 0;
                framePointer++;
                if (framePointer >= frames.Count)
                {
                    if (loop)
                    {
                        framePointer = 0;
                    }
                    else
                    {
                        break;
                    }

                }

                img.sprite = frames[framePointer];


            }
            yield return 0;
        }
        isPlaying = false;
        timeOut.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
