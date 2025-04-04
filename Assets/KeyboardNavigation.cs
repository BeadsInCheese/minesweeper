using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class KeyboardNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    public EventSystem eventSystem;
    private GameObject previouslySelected;
    private GameObject cache;
    void Start()
    {
        
    }
    public void findButton()
    {
        eventSystem.SetSelectedGameObject ( GameObject.FindFirstObjectByType<Button>().gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        bool mbdown = Input.GetMouseButtonDown(1);
        if (mbdown)
        {
            PointerEventData pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResultList = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResultList);

            foreach (var i in raycastResultList)
            {
                var hitObject = i.gameObject;

                if (hitObject.tag.Equals("tile"))
                {
                    eventSystem.SetSelectedGameObject(hitObject);
                    break;
                }
            }
        }


           

        
        if (Input.GetButtonDown("flag")||mbdown) {
            Debug.Log("flag");
            if (eventSystem.currentSelectedGameObject != null)
            {
                if (eventSystem.currentSelectedGameObject.tag.Equals("tile") && eventSystem.currentSelectedGameObject.GetComponent<Image>().color == new Color(0, 1, 0))
                {
                    eventSystem.currentSelectedGameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                }
                else { eventSystem.currentSelectedGameObject.GetComponent<Image>().color = new Color(0, 1, 0); }
            }
        }
        if (eventSystem.currentSelectedGameObject == null||! eventSystem.currentSelectedGameObject.activeInHierarchy)
        {
            if (cache != null && cache.activeInHierarchy)
            {
                eventSystem.SetSelectedGameObject(cache); 

            }
            findButton();
        }
        eventSystem.currentSelectedGameObject.transform.localScale = Vector3.one - 0.1f*Vector3.one*Mathf.Sin(Time.timeSinceLevelLoad*3);
        if (previouslySelected!=null&&eventSystem.currentSelectedGameObject != previouslySelected) { 
            previouslySelected.transform.localScale=Vector3.one;   
            cache=previouslySelected;
        }
        previouslySelected = eventSystem.currentSelectedGameObject;
        
    }
}
