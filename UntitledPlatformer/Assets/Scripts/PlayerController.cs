using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    public float jumpForce;
    public CharacterController controller;

    public float gravityScale;
    private Vector3 moveDirection;

    public Animator anim;
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    private float canJump = 0;

    public int maxjumps = 2;
    int jumps;

    public AudioSource croak;

    void Awake()
    {
        jumps = maxjumps;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveDirection.y;

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * movespeed, moveDirection.y, Input.GetAxis("Vertical") * movespeed);
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection = moveDirection.normalized * movespeed;

        moveDirection.y = yStore;
        if (controller.isGrounded)
        {

            anim.SetBool("isDoubleJumping", false);
            anim.SetBool("IsGrounded", controller.isGrounded);
            moveDirection.y = 0f;
            //if (Input.GetButtonDown("Jump") && Time.time > canJump)
            jumps = maxjumps;
        }

        if (Input.GetButtonDown("Jump"))
        {

            anim.SetBool("IsGrounded", false);
            Jump();


        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);

        controller.Move(moveDirection * Time.deltaTime);
        /*
        //Move the player in different directions based on camera look direction
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }*/
        anim.SetFloat("LSpeed", -Input.GetAxis("Horizontal"));
        anim.SetFloat("RSpeed", Input.GetAxis("Horizontal"));
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical"))));
    }

    void Jump()
    {
        if(jumps>0)
        {
            if (maxjumps != 1 && maxjumps != jumps)
            {
                anim.SetBool("isDoubleJumping", true);
            }
            moveDirection.y = jumpForce;
            croak.Play();
            jumps--;
            //Make double/triple/quad jumps spinning frog
            
        }
        if(jumps==0)
        {
            return;
        }
    }
    
}
