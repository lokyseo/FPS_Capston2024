using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inhence_WeaponRotate : MonoBehaviour
{
    public GameObject weapon;
    Quaternion firstAngles;
    
    float speed = 0.9f;
    float rotX, rotY;

    void Start()
    {

        firstAngles = weapon.transform.rotation;
        Debug.Log(weapon.transform.rotation);
    }

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
            transform.Rotate(Input.GetAxis("Mouse Y") * speed, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, firstAngles, 0.03f);

        }


    }
}
