using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float gravityScale = 1.0f;

    //establish the height of the jump
    [SerializeField]
    public float jumpForce = 10f;

    private float gravity = -9.8f;

    public bool isJumping = false;

    private Rigidbody rb;

    private CharacterController characterController;

    private RaycastController groundCheck;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<RaycastController>();
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
       float xMove = Input.GetAxis("Horizontal");
       float zMove = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.right * xMove) + (transform.forward * zMove);
        moveDirection.y += gravity * Time.deltaTime * gravityScale;
        moveDirection *= moveSpeed * Time.deltaTime;


        //code for jumping
        if ((Input.GetKeyDown(KeyCode.Space)) && groundCheck.isGrounded())
        {
            moveDirection.y += jumpForce * Time.deltaTime;
            Debug.Log("Jumping");
            isJumping = true;
        }

        characterController.Move(moveDirection);
    }


    //checks if the player is colliding with the floor to prevent double jumps
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + rb);
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            Debug.Log("Detecting ground");
        }
    }
}