using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Press_Start_F : MonoBehaviour
{

    bool isReadyToStart;
    bool isPressF;
    bool isGameFinish;

    public GameObject f_Image;
    public GameObject reward_window;

    float timeCount;
    public Text time_Text;

    void Start()
    {
        timeCount = 60;
        isReadyToStart = false;
        isPressF = false;
        isGameFinish = false;

        f_Image.SetActive(false);
        reward_window.SetActive(false); 
        time_Text.text = "Time : 00.00";
    }

    void Update()
    {
        if (isGameFinish)
        {
            reward_window.SetActive(true);

            return;
        }

        if (!isPressF)
        {
            if (isReadyToStart)
            {
                f_Image.SetActive(true);
                if(Input.GetKeyDown(KeyCode.F))
                {
                    isPressF =true;
                    f_Image.SetActive(false);

                }
            }
            else
            {
                f_Image.SetActive(false);

            }
        }
        else
        {
            timeCount -= Time.deltaTime;
            time_Text.text = "Time : " + timeCount.ToString("F2");

            if(timeCount < 0)
            {
                isPressF = false;
                isGameFinish = true;
                timeCount = 60;
            }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isReadyToStart = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isReadyToStart = false; 
        }
    }
}
