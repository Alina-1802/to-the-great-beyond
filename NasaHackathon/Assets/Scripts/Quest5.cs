using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest5 : MonoBehaviour
{
    public GameObject questPanel;
    public TMP_InputField inputfield;
    public bool isQuestCompleted = false;
    public Button sendButton;

    public TextMeshProUGUI correctText;
    public TextMeshProUGUI incorrectText;

    public TextMeshProUGUI answer;
    public TextMeshProUGUI correctAnswer;

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

    public void OnSendClicked()
    {
        string answerText = answer.text.Remove(answer.text.Length - 1).ToLower();
        string correctAnswerText = correctAnswer.text;

        if (answerText.Equals(correctAnswerText))
        {
            Debug.Log("Correct");
            isQuestCompleted = true;
            inputfield.interactable = false;
            sendButton.interactable = false;
            correctText.gameObject.SetActive(true);
            incorrectText.gameObject.SetActive(false);

            planetManager.isQuest5Completed = true;
            planetManager.UpdateCompletedQuestsText();
        }
        else
        {
            Debug.Log("Incorrect");
            incorrectText.gameObject.SetActive(true);
            correctText.gameObject.SetActive(false);
        }
    }
}
