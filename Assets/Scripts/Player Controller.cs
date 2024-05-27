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

    private float xInput;
    private float zInput;

    private Vector3 moveDirection;

    void Start()
    {
        
    }

    void Update()
    {
        xInput = joystick.Horizontal * movementSpeed;
        zInput = joystick.Vertical * movementSpeed;

        moveDirection = new Vector3(xInput, 0, zInput).normalized;

        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);
        }

        animator.SetFloat("xVelocity", Mathf.Abs(xInput));
        animator.SetFloat("zVelocity", Mathf.Abs(zInput));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(xInput, rb.velocity.y, zInput);
    }
}
