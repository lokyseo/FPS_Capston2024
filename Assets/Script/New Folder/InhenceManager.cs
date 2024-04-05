using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InhenceManager : MonoBehaviour
{
    public static bool isChangedParts;

    public Slider property_Slider;
    public Image[] property_Image;

    public Image[] slot_Image;   


    void Start()
    {
        isChangedParts = false;
    }

    void Update()
    {
        property_Image[0].rectTransform.sizeDelta = new Vector2(Parts_Drag.property * 50, 0);

        if(isChangedParts )
        {
            property_Slider.value = Parts_Drag.property;
            isChangedParts = false;
        }
    }


    public void OnClickBackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

  
}
