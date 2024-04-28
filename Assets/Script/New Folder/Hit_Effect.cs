using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Hit_Effect : MonoBehaviour
{
    Image hitImage;
    void Start()
    {
        hitImage = this.transform.GetComponent<Image>();
    }

    void Update()
    {
        Color tempColor = hitImage.color;

        tempColor.a *= 0.99f;
        hitImage.color = tempColor;

    }
}
