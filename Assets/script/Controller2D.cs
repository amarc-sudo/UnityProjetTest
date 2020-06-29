using System;
using UnityEngine;


public class Controller2D : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    public float moveSpeed;
    public float jumpForce;
    [SerializeField]
    private bool isJumping;
    [SerializeField]
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private Vector3 movement;
    [SerializeField]
    private float horizontalMovement;

    void Update() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded) {
            isJumping = true;
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
    }

    void FixedUpdate() {
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement) {
        Vector3 targetVelocity = new Vector2(_horizontalMovement * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (isJumping == true) {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity) {
        if (_velocity > 0.1f) {
            spriteRenderer.flipX = false;
        } 
        else if (_velocity < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
