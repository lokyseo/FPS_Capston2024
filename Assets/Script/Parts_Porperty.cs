using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Parts_Porperty : MonoBehaviour
{
    public int rand_parts;
    public float rand_Property;
    public string parts_str, property_str;

    public Sprite[] bullet_Sprite;
    public Sprite[] bulletBox_Sprite;
    public Sprite[] scope_Sprite;
    public Sprite[] handle_Sprite;


    public int weaponType;


    void Start()
    {
        weaponType = Random.Range(0, 3);
        switch (weaponType)
        {
            case 0:
                rand_parts = Random.Range(1, 5);
                switch (rand_parts)
                {
                    case 1: //≈∫√¢
                        parts_str = "≈∫√¢";
                        rand_Property = Random.Range(5, 16);
                        this.transform.tag = "BulletBox_Parts";
                        break;
                    case 2: //¡∂¡ÿ¡°
                        parts_str = "¡∂¡ÿ∞Ê";
                        rand_Property = Random.Range(2, 4);
                        if (rand_Property == 2)
                        {
                            rand_Property = 2;
                            this.GetComponent<Image>().sprite = scope_Sprite[0];

                        }
                        else
                        {
                            rand_Property = 4;
                            this.GetComponent<Image>().sprite = scope_Sprite[1];

                        }
                        this.transform.tag = "Aim_Parts";
                        break;
                    case 3: //√—æÀ
                        parts_str = "√—æÀ";
                        this.GetComponent<Image>().sprite = bullet_Sprite[weaponType];
                        rand_Property = Random.Range(2, 6);
                        this.transform.tag = "Bullet_Parts";

                        break;
                    case 4: //º’¿‚¿Ã
                        parts_str = "º’¿‚¿Ã";
                        rand_Property = Mathf.Floor(Random.Range(0.01f, 1.0f) * 100f) / 100f;
                        this.transform.tag = "handle_Parts";

                        break;
                }
               // this.GetComponent<Image>().color = Color.white;

                break;
            case 1:
                rand_parts = Random.Range(1, 5);
                switch (rand_parts)
                {
                    case 1: //≈∫√¢
                        parts_str = "≈∫√¢";
                        rand_Property = Random.Range(1, 4);
                        this.transform.tag = "BulletBox_Parts";
                        break;
                    case 2: //¡∂¡ÿ¡°
                        parts_str = "¡∂¡ÿ∞Ê";
                        this.GetComponent<Image>().sprite = scope_Sprite[weaponType];
                        rand_Property = Random.Range(2, 4);
                        if (rand_Property == 2)
                        {
                            rand_Property = 6;
                        }
                        else
                        {
                            rand_Property = 8;
                        }
                        this.transform.tag = "Aim_Parts";
                        break;
                    case 3: //√—æÀ
                        parts_str = "√—æÀ";
                        this.GetComponent<Image>().sprite = bullet_Sprite[weaponType];
                        rand_Property = Random.Range(10, 31);
                        this.transform.tag = "Bullet_Parts";

                        break;
                    case 4: //º’¿‚¿Ã
                        parts_str = "º’¿‚¿Ã";
                        rand_Property = Mathf.Floor(Random.Range(0.01f, 1.0f) * 100f) / 100f;
                        this.transform.tag = "handle_Parts";

                        break;
                }

                //this.GetComponent<Image>().color = Color.black;

                break;
            case 2:
                rand_parts = Random.Range(1, 4);
                switch (rand_parts)
                {
                    case 1: //≈∫√¢
                        parts_str = "≈∫√¢";
                        rand_Property = Random.Range(2, 8);
                        this.transform.tag = "BulletBox_Parts";
                        break;
                    case 2: //¡∂¡ÿ¡°
                        parts_str = "¡∂¡ÿ∞Ê";
                        this.GetComponent<Image>().sprite = scope_Sprite[1];
                        rand_Property = Random.Range(2, 4);
                        if (rand_Property == 2)
                        {
                            rand_Property = 1.5f;
                        }
                        else
                        {
                            rand_Property = 2;
                        }
                        this.transform.tag = "Aim_Parts";
                        break;
                    case 3: //√—æÀ
                        parts_str = "√—æÀ";
                        this.GetComponent<Image>().sprite = bullet_Sprite[weaponType];
                        rand_Property = Random.Range(3, 11);

                        this.transform.tag = "Bullet_Parts";
                        break;
                }
               // this.GetComponent<Image>().color = Color.red;

                break;
        }
       
    }
}
