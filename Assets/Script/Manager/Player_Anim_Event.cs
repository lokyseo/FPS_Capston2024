using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Anim_Event : MonoBehaviour
{
    public GameObject zoomx_Image;
    public GameObject zoomx4_Image;
    public GameObject testCamera;

    public void ZoomInOut()
    {
        switch (Player_Shot.weaponType)
        {
            case 1:

                zoomx_Image.gameObject.SetActive(true);
                testCamera.GetComponent<Camera>().fieldOfView -= 10;

                break;
            case 2:
                this.GetComponent<Animator>().SetBool("isSrZoom", true);
                this.GetComponent<Animator>().SetBool("isSrNoZoom", false);

                zoomx4_Image.gameObject.SetActive(true);
                testCamera.GetComponent<Camera>().fieldOfView -= 30;
                break;
            case 0:

                zoomx_Image.gameObject.SetActive(true);

                testCamera.GetComponent<Camera>().fieldOfView -= 10;
                break;
        }
    }

}
