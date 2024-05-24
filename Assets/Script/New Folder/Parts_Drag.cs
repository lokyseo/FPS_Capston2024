using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Parts_Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // 아이템 등록 스트립트

    public static GameObject saveGameObject;
    public static Vector3 startPosition;
    public static Transform startParent;
    public static float property;
    public static int weapon_Type_static;

    [SerializeField]
    Transform onDragParent;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        saveGameObject = this.gameObject;

        startPosition = this.transform.position;
        startParent = this.transform.parent;
        weapon_Type_static = this.GetComponent<Parts_Porperty>().weaponType;

        if (this.transform.parent.tag != "Inventory")
        {
            property = -this.GetComponent<Parts_Porperty>().rand_Property;

        }
        else
        {
            property = this.GetComponent<Parts_Porperty>().rand_Property;

        }
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(onDragParent);
    }

    public void OnDrag(PointerEventData eventdata)
    {
        //transform.localPosition = Input.mousePosition;
        transform.position = eventdata.position;
    }

    public void OnEndDrag(PointerEventData eventdata)
    {
        saveGameObject = null;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;

        property = 0;
        weapon_Type_static = 3;
        if (transform.parent == onDragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

   
    
}
