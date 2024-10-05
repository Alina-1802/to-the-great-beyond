using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public float angle = 0.001f;
    public TextMeshPro planetName;

    void Start()
    {
        
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
            Debug.Log("Kolizja");
        }
    }

    public void SetPlanetNameRotation()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        planetName.transform.LookAt(mainCamera.transform);
        planetName.transform.Rotate(0, 180, 0);
    }
}
