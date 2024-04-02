using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot_Drag : MonoBehaviour, IDropHandler
{
    GameObject Icon()
    {
        if (transform.childCount > 0)
            return transform.GetChild(0).gameObject;
        else
            return null;
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(Icon() ==null)
        {
            Parts_Drag.saveGameObject.transform.SetParent(this.transform);
            Parts_Drag.saveGameObject.transform.position = transform.position;
        }
    }

}
