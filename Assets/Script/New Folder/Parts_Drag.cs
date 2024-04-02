using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Parts_Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // 아이템 등록 스트립트

    public static GameObject saveGameObject;

    Vector3 startPosition;

    [SerializeField]
    Transform onDragParent;
    public Transform startParent;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        saveGameObject = this.gameObject;

        startPosition = transform.position;
        startParent = this.transform.parent;

        this.GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(onDragParent);
    }

    public void OnDrag(PointerEventData eventdata)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventdata)
    {
        saveGameObject = null;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;

        if(transform.parent == onDragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

   
    
}
