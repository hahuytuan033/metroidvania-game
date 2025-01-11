using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   public Rigidbody2D rb;
   [SerializeField] private float speed = 5f;

   float horizontalMovement;

   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
   }

   void Update()
   {
      horizontalMovement = Input.GetAxis("Horizontal");
   }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<float>();
    }
    {

    }
}