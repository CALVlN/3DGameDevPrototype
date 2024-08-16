using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float maxRotation;

    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 newVelocity = transform.forward * vertical * maxSpeed;
        rb.velocity = newVelocity;
        transform.Rotate(Vector3.up, horizontal * maxRotation * Time.fixedDeltaTime, 0f);
    }
}
