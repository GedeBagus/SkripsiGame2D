using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceMove : MonoBehaviour
{
    [SerializeField] private LayerMask TrapArea;
    // public float speed = 10f;
    // public Rigidbody2D rb;
    // [SerializeField] Transform areaCheckCollider;
    // const float areaCheckRadius = 0.2f;
    // private Rigidbody2D rb;
    // // private float moveSpeed;
    // private float dirX;
    // private bool facingRight = true;
    // private Vector3 localScale;
    // bool IsGrounded = false;
    
        
    // Start is called before the first frame update
    // void Start()
    // {
    //     // rb.velocity = transform.right * speed;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    // }

    // // void GroundCheck() {
    // //     IsGrounded = false;
    // //     Collider2D[] colliders = Physics2D.OverlapCircleAll(areaCheckCollider.position, areaCheckRadius, TrapArea);
    // //     if (colliders.Length > 0){
    // //         IsGrounded = true;
    // //     }
    // // }
    
    // private void OnTriggerEnter2D(Collider2D TrapArea) {
        
    // }

    // private void FixedUpdate() {
    //     GroundCheck();
    //     rb.velocity = new Vector2(dirX, rb.velocity.y);
    //     if (dirX > 0 && !facingRight)
    //     {
    //         Flip();
    //     } else if (dirX < 0 && facingRight)
    //     {
    //         Flip();
    //     }
    // }

    // private void Flip() {
    //     facingRight = !facingRight;

    //     transform.Rotate(0f, 180f, 0f);
    // }
    float dirX, moveSpeed = 6f;
	bool moveRight = true;

	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D TrapArea) {
        // transform.Rotate(0f, 180f, 0f);
        if (moveRight == true) {
            moveRight = false;
        }
        else {
            moveRight = true;
        }
    }

    void Update () {
	// 	if (transform.position.x > 4f)
	// 		moveRight = false;
	// 	if (transform.position.x < -4f)
	// 		moveRight = true;

		if (moveRight)
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
		else
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
	}

    
    
    // private void OnCollisionEnter2D(Collision2D TrapArea) {
    //     transform.Rotate(0f, 180f, 0f);
    // }

    
}
