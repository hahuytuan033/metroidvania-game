using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    Animator anim;
    private float horizontalMovement;
    private bool isGrounded;
    private int jumpCount;
    private const int jumpCountMax = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorContrllers();

        horizontalMovement = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.K) && (isGrounded || jumpCount < jumpCountMax))
        {
            Jump();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        jumpCount++;
    }

    void AnimatorContrllers()
    {
        bool isMoving= rb.linearVelocity.x !=0;
        anim.SetBool("isMoving", isMoving);

        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    void FixedUpdate()
    {
        // No animation updates needed
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }
}