using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{

    public float force = 30f;
    public float rotationForce = 30f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Move();
    }

    public void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(0, 0, verticalInput) * force * Time.deltaTime;
        rb.AddRelativeForce(movement);

        Vector3 rotation = new Vector3(0, horizontalInput, 0) * rotationForce * Time.deltaTime;
        transform.Rotate(rotation);

    }
}
