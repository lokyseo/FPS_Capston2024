using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject esc_menu;


    void Start()
    {
           
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(esc_menu.gameObject.activeSelf)
            {
                esc_menu.SetActive(false);
            }
            else
            {
                esc_menu.SetActive(true);
            }
        }
    }


    public void BackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
