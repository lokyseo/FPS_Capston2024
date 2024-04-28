using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCameraCtl : MonoBehaviour
{
    CinemachineFreeLook LobbyCamera;
    void Start()
    {
        LobbyCamera = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        LobbyCamera.m_XAxis.Value += 0.1f;
    }
}
