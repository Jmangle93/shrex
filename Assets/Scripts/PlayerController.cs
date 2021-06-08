using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    public float gravityScale;
    public float jumpForce;
    public float moveSpeed;
    public Transform pivot;
    public GameObject playerModel;
    public float rotateSpeed;
    // RigidBody definition in the script is to have dedicated, custom physics as I can tell. As opposed to CharacterController
    // public Rigidbody rigidBody;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Rotate the player based on movement
    void RotateWithMovement()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 )
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float yBeforeNormal = moveDirection.y;
        moveDirection = -(transform.forward * Input.GetAxis("Vertical")) - (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yBeforeNormal;

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        else if (controller.isGrounded)
        {
            moveDirection.y = 0f;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        RotateWithMovement();

        animator.SetBool("isGrounded", controller.isGrounded);
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical"))) + (Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}
