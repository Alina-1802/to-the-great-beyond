using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuggingFace.API;
using TMPro;

public class Chatbot : MonoBehaviour
{
    public TextMeshProUGUI question;
    public TextMeshProUGUI answer;
    public GameObject chatbotUI;

    void Start()
    {
        chatbotUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && chatbotUI.activeSelf == false)
        {
            chatbotUI.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Q) && chatbotUI.activeSelf == true)
        {
            chatbotUI.SetActive(false);
        }

        if(chatbotUI.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                AnswerQuestion();
            }
        }
    }

    public void AnswerQuestion()
    {
        string input = question.text;
        string data = "The nearest exoplanet is proxima centauri b";

        HuggingFaceAPI.QuestionAnswering(input, onSucces =>
        {
            Debug.Log(onSucces.answer);
            answer.text = onSucces.answer;
        }, onError =>
        {
            Debug.Log(onError);
        }, data);
    }
}
