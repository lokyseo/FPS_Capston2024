using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LobbyManager : MonoBehaviour
{
    public CinemachineFreeLook mainMapCamera;
    public CinemachineFreeLook punchKingMapCamera;
    public int checkPriority;
    public float checkTime;

    void Start()
    {
        checkTime = 0;
        mainMapCamera.Priority = 1;
        punchKingMapCamera.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;
        if (checkTime > 10.0f)
        {
            checkPriority = mainMapCamera.Priority;
            mainMapCamera.Priority = punchKingMapCamera.Priority;
            punchKingMapCamera.Priority = checkPriority;
            checkTime = 0;
        }
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
