using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Parts_Porperty : MonoBehaviour
{
    int rand_parts;
    int rand_Property;
    public string parts_str, property_str;
    void Start()
    {
        rand_parts = Random.Range(1, 2);
        switch(rand_parts) 
        {
            case 1: //źâ
                parts_str = "źâ";
                rand_Property = Random.Range(1, 4);
                if (rand_Property == 1)
                    property_str = "��ź �� +1";
                else if (rand_Property == 2)
                    property_str = "�����ӵ� +1";
                else if (rand_Property == 3)
                    property_str = "��ź �� +1\n�����ӵ� +1";
                break;
            case 2: //������
                rand_Property = Random.Range(1, 4);
                break;
            case 3: //�Ѿ�

                break;
            case 4: //������

                break;
            case 5: //����ü����

                break;
        }
    }

    void Update()
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
    }
    void OnMouseEnter()
    {
        Debug.Log("�ö��");
    }
}
