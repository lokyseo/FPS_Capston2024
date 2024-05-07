using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinClock : MonoBehaviour
{
    public float clockSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, clockSpeed * Time.deltaTime, 0);
    }
}
