using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FocusRequester : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject strt;
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(strt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
