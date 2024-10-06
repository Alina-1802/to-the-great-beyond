using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Quest3 : MonoBehaviour
{
    public TextMeshProUGUI answer1;
    public TextMeshProUGUI answer2;
    public TextMeshProUGUI answer3;
    public TextMeshProUGUI answer4;

    public TMP_InputField input1;
    public TMP_InputField input2;
    public TMP_InputField input3;
    public TMP_InputField input4;

    public int[] answers = new int[4];
    public int[] correctAnswers = new int[4];

    public TextMeshProUGUI correctText;
    public TextMeshProUGUI incorrectText;

    public Button replayButton;
    public Button submitButton;

    public GameObject questPanel;
    public bool isQuestCompleted = false;

    private PlanetManager planetManager;

    void Start()
    {
        questPanel.SetActive(false);
        planetManager = GameObject.FindObjectOfType<PlanetManager>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SpaceshipController>() != null)
        {
            StartQuest();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<SpaceshipController>() != null)
        {
            ExitQuest();
        }
    }

    public void StartQuest()
    {
        questPanel.SetActive(true);

    }

    public void ExitQuest()
    {
        questPanel.SetActive(false);
    }

    public void OnSubmitButtonClicked()
    {
        InitializeAnswers();
        int score = GetScore();

        if (score == 4)
        {
            //correct
            correctText.gameObject.SetActive(true);
            correctText.text = "correct 4/4";
            isQuestCompleted = true;

            planetManager.isQuest3Completed = true;
            planetManager.UpdateCompletedQuestsText(questPanel);
        }
        else
        {
            //incorrect
            incorrectText.gameObject.SetActive(true);
            incorrectText.text = "incorrect " + score + "/4";
            replayButton.gameObject.SetActive(true);

        }

        submitButton.interactable = false;
    }

    public void InitializeAnswers()
    {
        answers[0] = Int16.Parse(answer1.text.Remove(answer1.text.Length - 1));
        answers[1] = Int16.Parse(answer2.text.Remove(answer2.text.Length - 1));
        answers[2] = Int16.Parse(answer3.text.Remove(answer3.text.Length - 1));
        answers[3] = Int16.Parse(answer4.text.Remove(answer4.text.Length - 1));
    }

    public int GetScore()
    {
        int score = 0;

        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i] == correctAnswers[i])
            {
                score++;
            }
        }

        return score;
    }

    public void OnReplayButtonClicked()
    {
        LoadQuest();
    }

    public void LoadQuest()
    {
        submitButton.interactable = true;

        incorrectText.gameObject.SetActive(false);
        replayButton.gameObject.SetActive(false);

        answer1.text = "";
        answer2.text = "";
        answer3.text = "";
        answer4.text = "";

        input1.text = "";
        input2.text = "";
        input3.text = "";
        input4.text = "";

    }


}
