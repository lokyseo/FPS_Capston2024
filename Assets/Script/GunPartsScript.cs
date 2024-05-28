using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPartsScript : MonoBehaviour
{
    public GameObject[] arScope = new GameObject[2];
    public GameObject arHandle;
    public GameObject srScope;
    public GameObject srHandle;
    public GameObject gunScope;

    void Start()
    {

        if (PlayerPrefs.GetFloat("ARSlot2", 0) == 0)
        {
            arScope[0].SetActive(false);
            arScope[1].SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetFloat("ARSlot2", 0) == 2)
            {
                arScope[0].SetActive(true);
                arScope[1].SetActive(false);
            }
            else if (PlayerPrefs.GetFloat("ARSlot2", 0) == 4)
            {
                arScope[0].SetActive(false);
                arScope[1].SetActive(true);
            }
        }
        if (PlayerPrefs.GetFloat("ARSlot3", 0) == 0)
            arHandle.SetActive(false);

        if (PlayerPrefs.GetFloat("SRSlot2", 0) == 0)
            srScope.SetActive(false);
        if (PlayerPrefs.GetFloat("SRSlot3", 0) == 0)
            srHandle.SetActive(false);

        if (PlayerPrefs.GetFloat("GunSlot2", 0) == 0)
            gunScope.SetActive(false);


    }

 
}
