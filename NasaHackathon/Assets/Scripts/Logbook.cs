using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logbook : MonoBehaviour
{
    public bool isActive = true;
    public GameObject logbook;

    void Start()
    {
        logbook.SetActive(true);
        isActive = true;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F9) && !isActive)
        {
            logbook.SetActive(true);
            isActive = true;
        }
        else if(Input.GetKeyDown(KeyCode.F9) && isActive)
        {
            logbook.SetActive(false);
            isActive = false;
        }
    }
}
