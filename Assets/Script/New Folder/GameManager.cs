using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject esc_menu;
    public Slider vertical_Slider;
    public Slider horizontal_Slider;

    public GameObject Player;
    Player_Move playermove_scr;

    public Text vertical_Senesitivity;
    public Text horizontal_Senesitivity;


    void Start()
    {
        playermove_scr = Player.GetComponent<Player_Move>();

        vertical_Slider.maxValue = 10;
        vertical_Slider.minValue = 0.01f;
        vertical_Slider.value = PlayerPrefs.GetFloat("VerticalSensitivity", 0.8f);
        vertical_Senesitivity.text = PlayerPrefs.GetFloat("VerticalSensitivity", 0.8f).ToString("F1");

        horizontal_Slider.maxValue = 10;
        horizontal_Slider.minValue = 0.01f;
        horizontal_Slider.value = PlayerPrefs.GetFloat("HorizontalSensitivity", 0.8f);
        horizontal_Senesitivity.text = PlayerPrefs.GetFloat("HorizontalSensitivity", 0.8f).ToString("F1");


        Cursor.lockState = CursorLockMode.Locked;   // 마우스 커서를 화면 안에서 고정
        Cursor.visible = false;                     // 마우스 커서를 보이지 않도록 설정
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (esc_menu.gameObject.activeSelf)
            {
                esc_menu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                esc_menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
        }


    }
    public void BackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Restart()
    {
        SceneManager.LoadScene("PunchKing");
        PlayerPrefs.SetFloat("PunchKingScore", 0);
    }

    public void VerticalValueChanged()
    {
        //playermove_scr.lookSensitivity_V = vertical_Slider.value;
        vertical_Senesitivity.text = vertical_Slider.value.ToString("F2");
        PlayerPrefs.SetFloat("VerticalSensitivity", vertical_Slider.value);

    }
    public void HorizontalValueChanged()
    {
        PlayerPrefs.SetFloat("HorizontalSensitivity", vertical_Slider.value);

        playermove_scr.lookSensitivity_H = horizontal_Slider.value;
        horizontal_Senesitivity.text = horizontal_Slider.value.ToString("F2");
        PlayerPrefs.SetFloat("HorizontalSensitivity", horizontal_Slider.value);
    }

}
