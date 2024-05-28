using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Anim_Event : MonoBehaviour
{
    public GameObject zoomx_Image;
    public GameObject zoomx4_Image;
    public GameObject testCamera;

    float gunScope;
    float arScope;
    float srScope;

    void Start()
    {
        gunScope = 5 * PlayerPrefs.GetFloat("GunSlot2", 0);
        arScope = 5 * PlayerPrefs.GetFloat("ARSlot2", 0);
        srScope = 5 * PlayerPrefs.GetFloat("SRSlot2", 0);
    }

    public void ZoomInOut()
    {
        switch (Player_Shot.weaponType)
        {
            case 1:

                zoomx_Image.gameObject.SetActive(true);
                testCamera.GetComponent<Camera>().fieldOfView -= arScope;

                break;
            case 2:
                this.GetComponent<Animator>().SetBool("isSrZoom", true);
                this.GetComponent<Animator>().SetBool("isSrNoZoom", false);

                zoomx4_Image.gameObject.SetActive(true);
                testCamera.GetComponent<Camera>().fieldOfView -= srScope;
                break;
            case 0:

                zoomx_Image.gameObject.SetActive(true);

                testCamera.GetComponent<Camera>().fieldOfView -= gunScope;
                break;
        }
    }

}
