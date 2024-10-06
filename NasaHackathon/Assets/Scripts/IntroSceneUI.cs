using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneUI : MonoBehaviour
{
    public void OnButtonPlayClicked()
    {
        SceneManager.LoadScene("SpaceshipScene");
    }
}
