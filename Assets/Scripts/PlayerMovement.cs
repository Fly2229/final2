using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1, 10f)]private float moveSpeed = 5f;
    [SerializeField,Range(1,10f)]private float jumpForce = 10f;
    private Rigidbody2D rb;
    private float originalMoveSpeed;
    private float originalJumpForce;
    private float moveInput;
    private bool isGrounded; 
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private float checkRadius; // Radio para verificar el suelo
    [SerializeField] private LayerMask groundLayer; 
    [HideInInspector] public GameObject currentShield;

    private Animator animator; 
    private bool isRunning; 
    private bool isJumping;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        originalMoveSpeed = moveSpeed;
        originalJumpForce = jumpForce;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Activar animación de correr
        if (Mathf.Abs(moveInput) > 0 && isGrounded)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
        }

        // Desactivar animación de salto cuando el jugador aterriza
        if (isGrounded && !Input.GetKey(KeyCode.Space))
        {
            isJumping = false;
        }


        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isGrounded", isGrounded);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }


    // Métodos para la velocidad
    public void IncreaseSpeed(float multiplier) => moveSpeed *= multiplier;
    

    public void ResetSpeed() => moveSpeed = originalMoveSpeed;
    

    // Métodos para la fuerza de salto
    public void IncreaseJumpForce(float multiplier) =>  jumpForce *= multiplier;
    

    public void ResetJumpForce() => jumpForce = originalJumpForce;
    


    void OnDrawGizmos()
    {
       
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        
    }
}
