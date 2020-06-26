using System;
using UnityEngine;


public class Controller2D : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce = 300;

    public Rigidbody2D rb;

    public Vector3 vector = Vector3.zero;

    public Boolean isJump = false;
   


    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
            isJump = true;
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement){
        Vector3 targetXVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        Vector3 vector3 = Vector3.SmoothDamp(rb.velocity, targetXVelocity, ref vector, .05f);
        rb.velocity = vector3;
        if (isJump){
            rb.AddForce(new Vector2(0f, jumpForce));
            isJump = false;
        }
    }
}
