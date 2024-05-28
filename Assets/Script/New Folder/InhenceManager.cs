using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InhenceManager : MonoBehaviour
{
    public GameObject canvas_slot;

    public static bool isChangedParts;

    public Slider[] property_Slider; // 슬라이더
    public Image[] property_Image; // 슬라이더 변동 이미지

    public GameObject[] slot_Type;
    Image[] slot_Image = new Image[4]; // 슬롯 이미지

    public float[] basic_slider_Value = new float[4]; // 슬라이더 초기값
    float[] temp_slider_Value = new float[4]; // 임시 데이터값

    public GameObject[] weapon_array;
    public int weaponType;

    public Text[] slider_value_text;

    //0 : AR, 1 : SR, 2 : Gun     총알 탄창 조준경 손잡이

    void Start()
    {
         PlayerPrefs.DeleteAll();

        weaponType = 0;
        isChangedParts = false;
        //초기화

        if (weaponType == 0)
        { 
            basic_slider_Value[0] = 5;
            basic_slider_Value[2] = 0;
            basic_slider_Value[3] = 1.0f;
            basic_slider_Value[1] = 25;
        }                            
        else if (weaponType == 1)    
        {                            
            basic_slider_Value[0] = 30;
            basic_slider_Value[2] = 0;
            basic_slider_Value[3] = 1.0f;
            basic_slider_Value[1] = 5;
        }                            
        else                         
        {                            
            basic_slider_Value[0] = 8;
            basic_slider_Value[2] = 0;
            basic_slider_Value[3] = 1.0f;
            basic_slider_Value[1] = 8;
        }
        for(int i = 0; i < basic_slider_Value.Length; i++)
        {
            property_Slider[i].value = basic_slider_Value[i];
        }
        for (int i = 0; i < slot_Type[0].transform.childCount; i++)
        {
            slot_Image[i] = slot_Type[0].transform.GetChild(i).GetComponent<Image>();
        }

    }

    void Update()
    {
        if (Parts_Drag.property > 0) //인벤토리에서 드래그 됬을 때
        {
            for (int i = 0; i < 4; i++)
            {
                float test = (basic_slider_Value[i] + Parts_Drag.property) - property_Slider[i].value;
                if(Parts_Drag.saveGameObject.tag == property_Slider[i].tag && 
                    weaponType == Parts_Drag.weapon_Type_static)
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
                if (Parts_Drag.saveGameObject.tag == property_Slider[i].tag &&
                    weaponType == Parts_Drag.weapon_Type_static)
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
            for (int i = 0; i < slot_Type[weaponType].transform.childCount; i++)
            {
                temp_slider_Value[i] = 0;

                if (slot_Image[i].transform.childCount > 0)
                {
                    temp_slider_Value[i] += slot_Image[i].GetComponentInChildren<Parts_Porperty>().rand_Property;

                    switch (weaponType)
                    {
                        case 0:
                            PlayerPrefs.SetFloat("ARSlot" + i, slot_Image[i].GetComponentInChildren<Parts_Porperty>().rand_Property);

                            break;
                        case 1:
                            PlayerPrefs.SetFloat("SRSlot" + i, slot_Image[i].GetComponentInChildren<Parts_Porperty>().rand_Property);

                            break;
                        case 2:
                            PlayerPrefs.SetFloat("GunSlot" + i, slot_Image[i].GetComponentInChildren<Parts_Porperty>().rand_Property);

                            break;

                    }

                }
                else
                {
                    switch (weaponType)
                    {
                        case 0:
                            PlayerPrefs.SetFloat("ARSlot" + i, 0);

                            break;
                        case 1:
                            PlayerPrefs.SetFloat("SRSlot" + i, 0);

                            break;
                        case 2:
                            PlayerPrefs.SetFloat("GunSlot" + i, 0);

                            break;

                    }

                }

                property_Slider[i].value = basic_slider_Value[i] + temp_slider_Value[i];//test

            }

            isChangedParts = false;
        }

        for(int i = 0; i <slider_value_text.Length; i++)
        {
            slider_value_text[i].text = property_Slider[i].value.ToString("F2");
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
        if (weaponType == 0)
        {
            basic_slider_Value[0] = 5;
            basic_slider_Value[1] = 25;

        }
        else if (weaponType == 1)
        {
            basic_slider_Value[0] = 30;
            basic_slider_Value[1] = 5;
        }
        else
        {
            basic_slider_Value[0] = 8;
            basic_slider_Value[1] = 8;
        }

        basic_slider_Value[3] = 1.0f; // + playerprefab
        basic_slider_Value[2] = 0; // + playerprefab

        for (int i =0; i <weapon_array.Length; i++)
        {
            if(i == weaponType)
            {
                weapon_array[i].SetActive(true);
                slot_Type[i].SetActive(true);
                for(int j = 0; j < slot_Type[i].transform.childCount; j++)
                {
                    slot_Image[j] = slot_Type[i].transform.GetChild(j).GetComponent<Image>();
                    switch (weaponType)
                    {
                        case 0:
                            property_Slider[j].value = basic_slider_Value[j] + PlayerPrefs.GetFloat("ARSlot" + j, 0);

                            break;
                        case 1:
                            property_Slider[j].value = basic_slider_Value[j] + PlayerPrefs.GetFloat("SRSlot" + j, 0);

                            break;
                        case 2:
                            property_Slider[j].value = basic_slider_Value[j] + PlayerPrefs.GetFloat("GunSlot" + j, 0);

                            break;

                    }

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
        if (weaponType == 0)
        {
            basic_slider_Value[0] = 5;
            basic_slider_Value[1] = 25;

        }
        else if (weaponType == 1)
        {
            basic_slider_Value[0] = 30;
            basic_slider_Value[1] = 5;
        }
        else
        {
            basic_slider_Value[0] = 8;
            basic_slider_Value[1] = 8;
        }

        basic_slider_Value[3] = 1.0f; // + playerprefab
        basic_slider_Value[2] = 0; // + playerprefab

        for (int i = 0; i < weapon_array.Length; i++)
        {
            if (i == weaponType)
            {
                weapon_array[i].SetActive(true);
                slot_Type[i].SetActive(true);
                for (int j = 0; j < slot_Type[i].transform.childCount; j++)
                {
                    slot_Image[j] = slot_Type[i].transform.GetChild(j).GetComponent<Image>();
                    switch (weaponType)
                    {
                        case 0:
                            property_Slider[j].value = basic_slider_Value[j] + PlayerPrefs.GetFloat("ARSlot" + j, 0);

                            break;
                        case 1:
                            property_Slider[j].value = basic_slider_Value[j] + PlayerPrefs.GetFloat("SRSlot" + j, 0);

                            break;
                        case 2:
                            property_Slider[j].value = basic_slider_Value[j] + PlayerPrefs.GetFloat("GunSlot" + j, 0);

                            break;

                    }
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
