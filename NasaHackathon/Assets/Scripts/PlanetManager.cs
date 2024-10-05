using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public bool isQuest1Completed = false;
    public bool isQuest2Completed = false;
    public bool isQuest3Completed = false;
    public bool isQuest4Completed = false;
    public bool isQuest5Completed = false;

    public TextMeshProUGUI completedQuests;
    int numberCompletedQuests = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateCompletedQuestsText()
    {
        numberCompletedQuests++;
        completedQuests.text = "completed quests: " + numberCompletedQuests.ToString() + "/5";
    }
}
