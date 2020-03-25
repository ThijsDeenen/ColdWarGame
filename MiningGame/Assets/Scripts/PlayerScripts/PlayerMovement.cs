using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float sprintSpeed;
    private float speed;
    public float stamina;
    private float maxStamina;
    public float staminaDelay;
    private float maxStaminaDelay;

    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb2d;
    public Animator anim;

    public Transform groundPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool isJumping;
    private bool isSprinting;

    public GameObject playerStats;
    public Transform staminaMeter;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        speed = walkSpeed;
        maxStamina = stamina;
        maxStaminaDelay = staminaDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player is on ground
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        //Jumping
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            rb2d.velocity = Vector2.up * jumpForce;
        }

        //Sprinting
        if (isGrounded == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetSprinting(true);
        }
        if (isGrounded == true && Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetSprinting(false);
            
        }

        if (isSprinting)
        {
            stamina -= Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                SetSprinting(false);
            }
            staminaMeter.localScale = new Vector2(stamina / maxStamina, 1f);
        }
        else if (stamina < maxStamina)
        {
            stamina += Time.deltaTime;
            staminaMeter.localScale = new Vector2(stamina / maxStamina, 1f);
        }

        //Horizontal movement input
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        //Toggle walk animation
        if (moveInput == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else anim.SetBool("isWalking", true);

        //Flip player horizontally when switching between moving left and right
        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            playerStats.transform.eulerAngles = new Vector2(0, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            playerStats.transform.eulerAngles = new Vector2(0, 0);
        }
    }

    private void SetSprinting(bool currentlySprinting)
    {
        isSprinting = currentlySprinting;
        anim.SetBool("isSprinting", isSprinting);
        speed = isSprinting ? sprintSpeed : walkSpeed;
    }
}
