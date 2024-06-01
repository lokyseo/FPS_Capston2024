using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class LobbyButtonCtl : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public CinemachineVirtualCamera ButtonCamera;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        ButtonCamera.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonCamera.Priority = 1;
        audioSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonCamera.Priority = 0;
    }
}
