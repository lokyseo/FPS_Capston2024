using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamClockSpin : MonoBehaviour
{
    GameObject clockobjects;
    public float spiney = 0;
    public float spinespeed;
    void Start()
    {
        transform.eulerAngles = new Vector3(0, spiney, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, spinespeed, 0);
    }
}
