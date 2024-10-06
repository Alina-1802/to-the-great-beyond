using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPlanet1Completed = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }


}
