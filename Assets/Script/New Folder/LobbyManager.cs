using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LobbyManager : MonoBehaviour
{

    void Start()
    {
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
