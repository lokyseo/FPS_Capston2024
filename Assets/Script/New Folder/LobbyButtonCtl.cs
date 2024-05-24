using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class LobbyButtonCtl : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public CinemachineFreeLook ButtonCamera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonCamera.Priority = 1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonCamera.Priority = 0;
    }
}
