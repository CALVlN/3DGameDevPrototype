using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public Transform jumpCheckPosition;

    public float maxRotation = 15f;

    public float maxSpeed = 20f;

    public float jumpForce = 7f;

    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Input.GetButtonDown("Jump")) {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 newVelocity = transform.forward * vertical * maxSpeed;
        newVelocity.y = rb.velocity.y; // keep y velocity so gravity works
        rb.velocity = newVelocity;
        
        if (isJumping && Physics.OverlapSphere(jumpCheckPosition.position, 0.05f, LayerMask.GetMask("Ground")).Length > 0) {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            isJumping = false;
        }

        transform.Rotate(Vector3.up, horizontal * maxRotation * Time.fixedDeltaTime, 0f);
    }
}
