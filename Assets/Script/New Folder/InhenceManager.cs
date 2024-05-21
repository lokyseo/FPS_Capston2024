using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InhenceManager : MonoBehaviour
{
    public static bool isChangedParts;

    public Slider[] property_Slider; // 슬라이더
    public Image[] property_Image; // 슬라이더 변동 이미지

    public GameObject[] slot_Type;
    Image[] slot_Image = new Image[4]; // 슬롯 이미지

    public float[] basic_slider_Value = new float[4]; // 슬라이더 초기값
    float[] temp_slider_Value = new float[4]; // 임시 데이터값

    public GameObject[] weapon_array;
    public int weaponType; 
    
    //0 : AR, 1 : SR, 2 : Gun


    void Start()
    {
        weaponType = 0;
        isChangedParts = false;
        for(int i = 0; i< property_Slider.Length; i++)
        {
            basic_slider_Value[i] = property_Slider[i].value;

        }
    }

    void Update()
    {
        if (Parts_Drag.property > 0) //인벤토리에서 드래그 됬을 때
        {
            for (int i = 0; i < 4; i++)
            {
                float test = (basic_slider_Value[i] + Parts_Drag.property) - property_Slider[i].value;
                if(Parts_Drag.saveGameObject.tag == property_Slider[i].tag)
                {
                    if (property_Slider[i].value < (basic_slider_Value[i] + Parts_Drag.property))
                    {

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
                    PlayerPrefs.SetFloat("Slot" + i, slot_Image[i].GetComponentInChildren<Parts_Porperty>().rand_Property);
                }

                property_Slider[i].value = basic_slider_Value[i] + temp_slider_Value[i];//test

            }

            isChangedParts = false;
        }
    }

    public void LeftButton()
    {
        if (weaponType > 0)
        {
            weaponType--;
        }
        else
        {
            weaponType = 2;
        }

        for (int i =0; i <weapon_array.Length; i++)
        {
            if(i == weaponType)
            {
                weapon_array[i].SetActive(true);
                slot_Type[i].SetActive(true);
                for(int j = 0; j < slot_Type[i].transform.childCount; j++)
                {
                    slot_Image[j] = slot_Type[i].transform.GetChild(j).GetComponent<Image>();
                }
            }
            else
            {
                weapon_array[i].SetActive(false);
                slot_Type[i].SetActive(false);

            }
        }
       

    }

    public void RightButtton()
    {
        if (weaponType < 2)
        {
            weaponType++;
        }
        else
        {
            weaponType = 0;
        }

        for (int i = 0; i < weapon_array.Length; i++)
        {
            if (i == weaponType)
            {
                weapon_array[i].SetActive(true);
                slot_Type[i].SetActive(true);
                for (int j = 0; j < slot_Type[i].transform.childCount; j++)
                {
                    slot_Image[j] = slot_Type[i].transform.GetChild(j).GetComponent<Image>();
                }
            }
            else
            {
                weapon_array[i].SetActive(false);
                slot_Type[i].SetActive(false);
            }
        }
    }

    public void OnClickBackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

  
}
