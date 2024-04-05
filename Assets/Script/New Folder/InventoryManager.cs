using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IDropHandler
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

        for (int i = 0; i < this.transform.childCount;)
        {

            if (this.transform.GetChild(i).Icon() != null)
            {
                Parts_Drag.saveGameObject.transform.SetParent(this.transform.GetChild(i).transform);
                Parts_Drag.saveGameObject.transform.position = this.transform.GetChild(i).position;
                break;
            }
            else
            {
                i++;
            }
        }


    }
}
