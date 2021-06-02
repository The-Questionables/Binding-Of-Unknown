using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler
{
   // private bool mouse_over = false;
    public GameObject popupWindowObject;

    // Start is called before the first frame update
    void Start()
    {
       popupWindowObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (mouse_over)
        {
            Debug.Log("Mouse Over");
            popupWindowObject.SetActive(true);
        }
        else
        {
            Debug.Log("Mouse Over");
          //  popupWindowObject.SetActive(false);
        }
        */
    }

   // public void OnPointerExit(PointerEventData eventData)
    //{
        //mouse_over = false;
    //    Debug.Log("Mouse exit");
   // }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //mouse_over = true;
        popupWindowObject.SetActive(true);
    }
}
