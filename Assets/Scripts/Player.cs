using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 6f;
    private int jumpCount;
    private int jumpCountMax = 2; // số lần nhảy tối đa
    public LayerMask groundLayer;
    bool isGrounded;
    private Rigidbody2D rb;
    float horizontalMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // move the player
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);


        //jump the player
        if (Input.GetKeyDown(KeyCode.K) && jumpCount < jumpCountMax)
        {
            jump();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    void jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        jumpCount++;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reset số lần nhảy khi chạm đất
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