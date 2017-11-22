using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveVector;
    public Transform _player;

    public float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 4.0f;

    private bool isDead = false;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_player.position.x);

        Border(_player.position.x);

        if (isDead)
        {
            return;
        }

        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        // Y - Up and Down

        // Z - Forward and Backward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

    //It is being called ebery time our capsule hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
        {
            Death();
        }
    }

    public void Border(float x)
    {


        if (x > 4.5 || x < -5)
        {
            Debug.Log("Blocked");
        }
    }

    private void Death()
    {
        isDead = true;
        Debug.Log("Death");
    }
}