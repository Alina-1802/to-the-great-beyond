using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetManager : MonoBehaviour
{
    public bool isQuest1Completed = false;
    public bool isQuest2Completed = false;
    public bool isQuest3Completed = false;
    public bool isQuest4Completed = false;
    public bool isQuest5Completed = false;

    public TextMeshProUGUI completedQuests;
    int numberCompletedQuests = 0;

    public int planetNumber = 1;

    private GameManager gameManager;
    public GameObject chatbotUI;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !chatbotUI.activeSelf)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateCompletedQuestsText()
    {
        numberCompletedQuests++;
        completedQuests.text = "completed quests: " + numberCompletedQuests.ToString() + "/5";

        if(numberCompletedQuests == 5)
        {
            switch(planetNumber)
            {
                case 1:
                    {
                        gameManager.isPlanet1Completed = true;
                        break;
                    }
                case 2:
                    {
                        gameManager.isPlanet2Completed = true;
                        break;
                    }
                case 3:
                    {
                        gameManager.isPlanet3Completed = true;
                        break;
                    }
            }
        }
    }
}
