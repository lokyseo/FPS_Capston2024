using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InhenceManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
        
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            
        }

    }

  
}
