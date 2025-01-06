using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }
}
