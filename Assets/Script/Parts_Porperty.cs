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
                        rand_Property = Random.Range(5, 15);
                        this.transform.tag = "BulletBox_Parts";
                        break;
                    case 2: //¡∂¡ÿ¡°
                        parts_str = "¡∂¡ÿ∞Ê";
                        rand_Property = Random.Range(2, 3);
                        if(rand_Property == 2)
                        {
                            rand_Property = 2;
                        }
                        else
                        {
                            rand_Property = 4;
                        }
                        this.transform.tag = "Aim_Parts";
                        break;
                    case 3: //√—æÀ
                        parts_str = "√—æÀ";
                        rand_Property = Random.Range(1, 4);
                        this.transform.tag = "Bullet_Parts";

                        break;
                    case 4: //º’¿‚¿Ã
                        parts_str = "º’¿‚¿Ã";
                        rand_Property = Random.Range(0, 1.0f);
                        this.transform.tag = "handle_Parts";

                        break;
                }
                this.GetComponent<Image>().color = Color.white;

                break;
            case 1:
                rand_parts = Random.Range(1, 5);
                switch (rand_parts)
                {
                    case 1: //≈∫√¢
                        parts_str = "≈∫√¢";
                        rand_Property = Random.Range(1, 3);
                        this.transform.tag = "BulletBox_Parts";
                        break;
                    case 2: //¡∂¡ÿ¡°
                        parts_str = "¡∂¡ÿ∞Ê";
                        rand_Property = Random.Range(2, 3);
                        if (rand_Property == 2)
                        {
                            rand_Property = 4;
                        }
                        else
                        {
                            rand_Property = 6;
                        }
                        this.transform.tag = "Aim_Parts";
                        break;
                    case 3: //√—æÀ
                        parts_str = "√—æÀ";
                        rand_Property = Random.Range(5, 20);
                        this.transform.tag = "Bullet_Parts";

                        break;
                    case 4: //º’¿‚¿Ã
                        parts_str = "≈∫√¢";
                        rand_Property = Random.Range(0, 1.0f);
                        this.transform.tag = "handle_Parts";

                        break;
                }

                this.GetComponent<Image>().color = Color.black;

                break;
            case 2:
                rand_parts = Random.Range(1, 4);
                switch (rand_parts)
                {
                    case 1: //≈∫√¢
                        parts_str = "≈∫√¢";
                        rand_Property = Random.Range(2, 7);
                        this.transform.tag = "BulletBox_Parts";
                        break;
                    case 2: //¡∂¡ÿ¡°
                        parts_str = "¡∂¡ÿ∞Ê";
                        rand_Property = Random.Range(2, 3);
                        if (rand_Property == 2)
                        {
                            rand_Property = 1;
                        }
                        else
                        {
                            rand_Property = 2;
                        }
                        this.transform.tag = "Aim_Parts";
                        break;
                    case 3: //√—æÀ
                        parts_str = "√—æÀ";
                        rand_Property = Random.Range(3, 10);
                        this.transform.tag = "Bullet_Parts";

                        break;
                }
                this.GetComponent<Image>().color = Color.red;

                break;
        }
       
    }
}
