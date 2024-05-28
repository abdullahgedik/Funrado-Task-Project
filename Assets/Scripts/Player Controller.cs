using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Joystick joystick;

    [Header("Settings")]
    [SerializeField] private float movementSpeed = 4f;

    private Vector3 input;
    private Vector3 moveDirection;

    void Update()
    {
        input.x = joystick.Horizontal * movementSpeed;
        input.z = joystick.Vertical * movementSpeed;

        moveDirection = input.normalized;

        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);
        }

        animator.SetFloat("xVelocity", Mathf.Abs(input.x));
        animator.SetFloat("zVelocity", Mathf.Abs(input.z));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(input.x, rb.velocity.y, input.z);
    }
}
