using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    // Start is called before the first frame update
    Image img;
    public float length = 1.0f;
    bool fo = false;
    bool fi=false;
    public static FadeController instance;
    IEnumerator fadein()
    {
        float timer = 0;
        fi = true;
        while (timer < length&&fi)
        {
            timer += Time.deltaTime;
            img.material.SetFloat("_Treshold", ( timer/length));
            yield return 0;
        }
        if (!fo)
        {
            img.material.SetFloat("_Treshold", 1);
        }
        fi = false;
    }
    IEnumerator fadeout()
    {
        float timer = 0;
        fo= true;
        while (timer < length&&fo)
        {
            timer += Time.deltaTime;
            img.material.SetFloat("_Treshold", 1.0f-(timer / length));
            yield return 0;
        }
        if (!fi)
        {
            img.material.SetFloat("_Treshold", 0);
        }
        fo= false;
        
    }
    public IEnumerator changeSceneWithTransition(string scene)
    {
        yield return fadeout();
        SceneManager.LoadScene(scene);

    }
    void Awake()
    {
        if (instance != null) { 
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(transform.parent.gameObject);
        img= GetComponent<Image>();
        SceneManager.activeSceneChanged += (Scene s1, Scene s2) => { StartCoroutine(fadein()); };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
