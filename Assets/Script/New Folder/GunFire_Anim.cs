using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire_Anim : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("IsFire");

        }
    }
}
