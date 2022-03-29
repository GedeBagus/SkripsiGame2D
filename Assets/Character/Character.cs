using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private LayerMask ground;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] private Text healthText;

    public HealthBar healthBarr;

    const float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    bool isHurting, isDead;
    private Vector3 localScale;
    bool IsGrounded = false;
    public int playerHealth = 100;
    public int currentHealth;   
        
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = playerHealth.ToString("0");
        currentHealth = playerHealth;
        healthBarr.SetMaxHealth(playerHealth);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead){
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        }

        if (Input.GetButtonDown("Jump") && !isDead && IsGrounded == true)
        {
            rb.AddForce(Vector2.up * 550f);                       
        }

        if (Mathf.Abs(dirX) > 0)
        {
            anim.SetBool("isRunning", true);
        } else
        {
            anim.SetBool("isRunning", false);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);            
        }

        if (rb.velocity.y > 5 && IsGrounded == false)
        {
            anim.SetBool("isJumping", true);
        }

        if (rb.velocity.y < -1 && IsGrounded == false)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
    }

    // private bool IsGrounded() {
    //     return transform.Find("GroundCheck").GetComponent<GroundCheck>().IsGrounded;
    // }

    void GroundCheck() {
        IsGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, ground);
        if (colliders.Length > 0){
            IsGrounded = true;
        }
    }
    
    private void FixedUpdate() {
        GroundCheck();
        if (!isHurting){
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        }
        if (dirX > 0 && !facingRight)
        {
            Flip();
        } else if (dirX < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip() {
        // if (dirX > 0)
        // {
        //     facingRight = true;
        // } else if (dirX < 0)
        // {
        //     facingRight = false;
        // }

        // if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        // {
        //     localScale.x *= -1;
            
        // }
        // transform.localScale = localScale;

        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void UpdateHealth()
    {
        healthText.text = currentHealth.ToString("0");
        healthBarr.SetHealth(currentHealth);
        
        if (currentHealth <= 0){
            dirX = 0;
            isDead = true;
            anim.SetTrigger("isDead");
            Debug.Log("Game Over");
        }
        else{
            anim.SetTrigger ("isHurting");
            StartCoroutine ("Hurt");

        }
    }

    IEnumerator Hurt()
    {
        isHurting = true;
        rb.velocity = Vector2.zero;

        if (facingRight){
            rb.AddForce (new Vector2(-200f, 300f));
        }
        else{
            rb.AddForce (new Vector2(200f, 300f));
        }
        // rb.AddForce(Vector2.up * 200f);

        yield return new WaitForSeconds(0.5f);

        isHurting = false;
    }
}
 