using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InhenceManager : MonoBehaviour
{
    public static bool isChangedParts;

    public Slider property_Slider;
    public Image[] property_Image;

    public Image[] slot_Image;

    public static float basic_slider_Value;
    float[] temp_slider_Value = new float[4];

    void Start()
    {
        isChangedParts = false;
        basic_slider_Value = property_Slider.value;
    }

    void Update()
    {
        if(Parts_Drag.property > 0)
        {
            property_Image[0].transform.localScale = new Vector3(1, 1, 1);
            property_Image[0].rectTransform.sizeDelta = new Vector2(Parts_Drag.property * 50, 0);
        }
        else
        {
            property_Image[0].transform.localScale = new Vector3(-1, 1, 1);
            property_Image[0].rectTransform.sizeDelta = new Vector2(Parts_Drag.property * -50, 0);

        }



        if (isChangedParts )
        {
            for (int i = 0; i < slot_Image.Length; i++)
            {
                temp_slider_Value[i] = 0;

                if (slot_Image[i].transform.childCount > 0)
                {
                    temp_slider_Value[i] += slot_Image[i].GetComponentInChildren<Parts_Porperty>().rand_Property;
                }
                else
                {
                }
            }

            property_Slider.value = basic_slider_Value + temp_slider_Value[0];//test
            isChangedParts = false;
        }
    }


    public void OnClickBackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

  
}
