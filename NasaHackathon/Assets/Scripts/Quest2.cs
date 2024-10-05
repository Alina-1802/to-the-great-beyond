using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Quest2 : MonoBehaviour
{
    public GameObject questPanel;
    public GameObject question1Panel;
    public GameObject question2Panel;
    public GameObject question3Panel;
    public GameObject question4Panel;
    public GameObject question5Panel;

    public Button submitButton;
    public Button replayButton;

    public TextMeshProUGUI correctText;
    public TextMeshProUGUI incorrectText;

    private int[] answers = new int[5];
    public int[] correctAnswers = {1, 3, 2, 1, 2};

    public int selectedButton;
    public int currentQuestion = 1;
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

        if(currentQuestion == 1)
        {
            question1Panel.SetActive(true);
        }
    }

    public void ExitQuest()
    {
        questPanel.SetActive(false);
    }

    public void OnNextButtonClicked()
    {
        switch(currentQuestion)
        {
            case 1:
                {
                    answers[0] = selectedButton;
                    question1Panel.SetActive(false);
                    question2Panel.SetActive(true);
                    break;
                }
            case 2:
                {
                    answers[1] = selectedButton;
                    question2Panel.SetActive(false);
                    question3Panel.SetActive(true);
                    break;
                }
            case 3:
                {
                    answers[2] = selectedButton;
                    question3Panel.SetActive(false);
                    question4Panel.SetActive(true);
                    break;
                }
            case 4:
                {
                    answers[3] = selectedButton;
                    question4Panel.SetActive(false);
                    question5Panel.SetActive(true);
                    break;
                }
            case 5:
                {
                    answers[4] = selectedButton;
                    break;
                }
        }

        if(currentQuestion < 5)
        {
            currentQuestion++;
        }
    }

    public void OnAnswerButtonClicked(int number)
    {
        selectedButton = number;
    }

    public void OnSubmitButtonClicked()
    {
        answers[4] = selectedButton;

        int score = GetScore();

        if (score == 5)
        {
            //correct
            correctText.gameObject.SetActive(true);
            correctText.text = "correct 5/5";
            isQuestCompleted = true;

            planetManager.isQuest2Completed = true;
            planetManager.UpdateCompletedQuestsText();
        }
        else
        {
            incorrectText.gameObject.SetActive(true);
            incorrectText.text = "incorrect " + score + "/5";
            replayButton.gameObject.SetActive(true);
            //incorrect
        }

        submitButton.interactable = false;
    }

    public int GetScore()
    {
        int score = 0;

        for(int i = 0; i < answers.Length; i++)
        {
            if(answers[i] == correctAnswers[i])
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
        currentQuestion = 1;

        submitButton.interactable = true;

        incorrectText.gameObject.SetActive(false);
        replayButton.gameObject.SetActive(false);
        question5Panel.gameObject.SetActive(false);
        question1Panel.gameObject.SetActive(true);

    }
}
