using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.EventSystems;

public class LobbyManager : MonoBehaviour
{
    public CinemachineFreeLook mainMapCamera;
    public CinemachineFreeLook punchKingMapCamera;
    public int checkPriority;
    public float checkTime;

    void Start()
    {
        checkTime = 0;
        mainMapCamera.Priority = 0;
        punchKingMapCamera.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Training()
    {
        SceneManager.LoadScene("Main");
    }
    public void PunchKing()
    {
        SceneManager.LoadScene("PunchKing");
    }
    public void MainGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void Inhencement()
    {
        SceneManager.LoadScene("Inhence");
    }

}
