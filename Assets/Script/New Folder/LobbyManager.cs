using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    // Start is called before the first frame update
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
        SceneManager.LoadScene("Main");
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
