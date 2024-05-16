using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InhenceManager : MonoBehaviour
{
    public static bool isChangedParts;

    public Slider[] property_Slider;
    public Image[] property_Image;

    public Image[] slot_Image;

    public float[] basic_slider_Value = new float[4];
    float[] temp_slider_Value = new float[4];

    void Start()
    {
        isChangedParts = false;
        for(int i = 0; i< property_Slider.Length; i++)
        {
            basic_slider_Value[i] = property_Slider[i].value;

        }
    }

    void Update()
    {

        if(Parts_Drag.property > 0) //인벤토리에서 드래그 됬을 때
        {
            for (int i = 0; i < 4; i++)
            {
                float test = (basic_slider_Value[i] + Parts_Drag.property) - property_Slider[i].value;
                if(Parts_Drag.saveGameObject.tag == property_Slider[i].tag)
                {
                    if (property_Slider[i].value < (basic_slider_Value[i] + Parts_Drag.property))
                    {
                        //Debug.Log(test);

                        property_Image[i].transform.localScale = new Vector3(1, 1, 1);

                        property_Image[i].rectTransform.sizeDelta = new Vector2(test * (500 / property_Slider[i].maxValue), 0);
                    }
                    else
                    {
                        property_Image[i].transform.localScale = new Vector3(-1, 1, 1);

                        property_Image[i].rectTransform.sizeDelta =
                            new Vector2(test * -(500 / property_Slider[i].maxValue), 0);

                    }
                }
                
            }
            
        }
        else if (Parts_Drag.property < 0)//슬롯에서 드래그 됬을 때
        {
           // if (Parts_Drag.saveGameObject == null) return;
            for (int i = 0; i < 4; i++)
            {
                if (Parts_Drag.saveGameObject.tag == property_Slider[i].tag)
                {
                  property_Image[i].transform.localScale = new Vector3(-1, 1, 1);
                  property_Image[i].rectTransform.sizeDelta = new Vector2(Parts_Drag.property * -(500 / property_Slider[i].maxValue), 0);
                }
            }

        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                property_Image[i].transform.localScale = new Vector3(0, 1, 1);
                property_Image[i].rectTransform.sizeDelta = new Vector2(Parts_Drag.property * -(500 / property_Slider[i].maxValue), 0);
            }
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

                property_Slider[i].value = basic_slider_Value[i] + temp_slider_Value[i];//test

            }

            isChangedParts = false;
        }
    }


    public void OnClickBackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

  
}
