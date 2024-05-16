using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Parts_Porperty : MonoBehaviour
{
    public float rand_parts;
    public float rand_Property;
    public string parts_str, property_str;
    void Start()
    {
        rand_parts = Random.Range(1, 4);
        switch(rand_parts) 
        {
            case 1: //탄창
                parts_str = "탄창";
                rand_Property = Random.Range(1, 4);
                if (rand_Property == 1)
                    property_str = "장탄 수 +1";
                else if (rand_Property == 2)
                    property_str = "장전속도 +1";
                else if (rand_Property == 3)
                    property_str = "장탄 수 +1\n장전속도 +1";
                break;
            case 2: //조준점
                parts_str = "조준경";
                rand_Property = Random.Range(1, 4);
                if (rand_Property == 1)
                    property_str = "2배율";
                else if (rand_Property == 2)
                    property_str = "3배율";
                else if (rand_Property == 3)
                    property_str = "4배율";
                break;
            case 3: //총알
                parts_str = "총알";
                rand_Property = Random.Range(1, 4);
                if (rand_Property == 1)
                    property_str = "장탄 수 +1";
                else if (rand_Property == 2)
                    property_str = "장전속도 +1";
                else if (rand_Property == 3)
                    property_str = "장탄 수 +1\n장전속도 +1";
                break;
            case 4: //손잡이
                parts_str = "탄창";
                rand_Property = Random.Range(1, 4);
                if (rand_Property == 1)
                    property_str = "장탄 수 +1";
                else if (rand_Property == 2)
                    property_str = "장전속도 +1";
                else if (rand_Property == 3)
                    property_str = "장탄 수 +1\n장전속도 +1";
                break;
            case 5: //투사체전용

                break;
        }
    }

    void Update()
    {
    }
  
}
