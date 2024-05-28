using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot_Drag : MonoBehaviour, IDropHandler
{
    public GameObject manager;
    public int weaponType;
    // weaponType = manager.GetComponent<InhenceManager>().weaponType;


    void Update()
    {
        weaponType = manager.GetComponent<InhenceManager>().weaponType;

    }
    GameObject Icon()
    {
        if (transform.childCount > 0)
            return transform.GetChild(0).gameObject;
        else
            return null;
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(Parts_Drag.saveGameObject == null) return;
        if (this.tag == "Inventory")
        {
            for(int i = 0; i < this.transform.parent.childCount;)
            {
                
                if (this.transform.parent.GetChild(i).childCount == 0)
                {
                    Parts_Drag.saveGameObject.transform.SetParent(this.transform.parent.GetChild(i).transform);
                    Parts_Drag.saveGameObject.transform.position = this.transform.parent.GetChild(i).position;
                    InhenceManager.isChangedParts = true;
                    break;
                }
                else
                {
                    i++;
                }
            }
            
        }
        else
        {
            if (Icon() == null)
            {
                if (Parts_Drag.saveGameObject.tag == this.gameObject.tag && Parts_Drag.weapon_Type_static == weaponType)
                {
                    Parts_Drag.saveGameObject.transform.SetParent(this.transform);
                    Parts_Drag.saveGameObject.transform.position = transform.position;
                    InhenceManager.isChangedParts = true;
                }

            }
            else
            {
                if (Parts_Drag.saveGameObject.tag == this.gameObject.tag && Parts_Drag.weapon_Type_static == weaponType)
                {
                    Icon().transform.position = Parts_Drag.startPosition;
                    Icon().transform.SetParent(Parts_Drag.startParent);
                    //property = Icon().GetComponent<Parts_Porperty>().rand_Property;

                    Parts_Drag.saveGameObject.transform.SetParent(this.transform);
                    Parts_Drag.saveGameObject.transform.position = transform.position;

                    InhenceManager.isChangedParts = true;
                }
     
            }
        }
        
    }

}
