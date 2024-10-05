using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPlanet1Completed = false;
    public bool isPlanet2Completed = false;
    public bool isPlanet3Completed = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // load proper scene when planet is interactive
        if(Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene(1);
        }
    }
}
