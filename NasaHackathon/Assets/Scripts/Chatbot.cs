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
        string data = "An exoplanet is a planet outside our solar system, usually orbiting another star. They are also sometimes called \"extrasolar planets,\" \"extra-\" implying that they are outside of our solar system. Proxima Centauri was discovered in 2016. Proxima Centauri b is the closest planet to Earth. Gas giants are planets the size of Saturn or Jupiter, the largest planet in our solar system, or much, much larger. Neptunian planets are similar in size to Neptune or Uranus in our solar system. Super-Earths are typically terrestrial planets that may or may not have atmospheres. They are more massive than Earth, but lighter than Neptune. Terrestrial planets are Earth sized and smaller, composed of rock, silicate, water or carbon. Further investigation will determine whether some of them possess atmospheres, oceans or other signs of habitability. Proxima Centauri b is a Super-Earth. We have discovered more than 5500 exoplanets. Proxima Centauri b is 4 light years away from Earth. Kepler-10 b is a super Earth exoplanet that orbits a G-type star. 55 Cancri e is an exoplanet covered in a global ocean of lava and has sparkling skies. GJ 504 b is a gas giant. First exoplanet was discovered in 1992. Super-Earth is a reference only to an exoplanet’s size. The most similar planet to Earth is TRAPPIST-1e. There are five methods scientists commonly use to discover exoplanets. The two main techniques are the transit and radial velocity methods. When a planet passes directly between an observer and the star it orbits, it blocks some of that starlight. For a brief period of time, that star’s light actually gets dimmer. It's a tiny change, but it's enough to clue astronomers in to the presence of an exoplanet around a distant star. This is known as the transit method. Most of the exoplanets discovered so far are in a relatively small region of our galaxy, the Milky Way. (\"Small\" meaning within thousands of light-years of our solar system; one light-year equals 5.88 trillion miles, or 9.46 trillion kilometers.) That is as far as current telescopes have been able to probe. We know from NASA’s Kepler Space Telescope that there are more planets than stars in the galaxy. Although exoplanets are far – even the closest known exoplanet to Earth, Proxima Centauri b, is still about 4 light-years away – scientists have discovered creative ways to spot these seemingly tiny objects. A person won't go to an exoplanet soon, given the enormous distances between the stars and the time it would take to travel between them with our current technology. Most of the exoplanets discovered so far are in a relatively small region of our galaxy, the Milky Way. To date, more than 5,500 exoplanets have been discovered and are considered \"confirmed\" by NASA, out of the billions in our galaxy alone. Earth is the only planet we know of with life on it...so far. Scientists are searching the galaxy for planets similar to Earth, and signs of life. The definition of “habitable zone” is the distance from a star at which liquid water could exist on orbiting planets’ surfaces. Habitable zones are also known as Goldilocks’ zones, where conditions might be just right – neither too hot nor too cold – for life.";

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
