using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlanetController : MonoBehaviour
{
    private float angle = 0.0005f;
    public TextMeshPro planetName;
    public GameObject planetDescription;

    public int planetNumber;

    void Start()
    {
        planetDescription.SetActive(false);
    }


    void Update()
    {
        transform.RotateAround(Vector3.up, angle);

        SetPlanetNameRotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SpaceshipController>() != null)
        {
            Debug.Log("Kolizja ze statkiem");
            planetDescription.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<SpaceshipController>() != null)
        {
            Debug.Log("Wyjscie z kolizji ze statkiem");
            planetDescription.SetActive(false);
        }
    }

    public void SetPlanetNameRotation()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        planetName.transform.LookAt(mainCamera.transform);
        planetName.transform.Rotate(0, 180, 0);
    }

    public void OnLandOnPlanetClicked()
    {
        SceneManager.LoadScene("Planet1");
    }
}
