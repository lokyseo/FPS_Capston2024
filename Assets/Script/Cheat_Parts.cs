using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat_Parts : MonoBehaviour
{
    public GameObject parts;
    public GameObject slot_first;
    void OnEnable()
    {
        for (int i = 0; i < Save_Slot.createCount; i++)
        {
            CreateParts();
        }
    }

    void OnDisable()
    {
        Save_Slot.createCount = 0;

    }
    void Update()
    {
        
    }


    public void CreateParts()
    {
        GameObject temp = Instantiate(parts);
        for (int i = 0; i < slot_first.transform.parent.childCount;)
        {

            if (slot_first.transform.parent.GetChild(i).childCount == 0)
            {
                temp.transform.SetParent(slot_first.transform.parent.GetChild(i).transform);
                temp.transform.position = slot_first.transform.parent.GetChild(i).position;
                break;
            }
            else
            {
                i++;
            }
        }
        //Debug.Log("adgnsduognasliopgasd");

    }
}
