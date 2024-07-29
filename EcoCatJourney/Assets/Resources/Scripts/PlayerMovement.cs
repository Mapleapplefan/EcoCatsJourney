using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 25f;
    private bool isFacingRight= false;
     public bool deathState = false;
    private bool isGrounded;

[SerializeField] private Rigidbody2D rb;
[SerializeField] private Transform groundCheck;
[SerializeField] private LayerMask groundLayer; //add later
     void Update()
    {
        if (deathState)
            return;

        // Handle horizontal movement
        horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);
        rb.velocity = movement;

        // Handle flipping the character
        if (horizontal > 0 && !isFacingRight)
            Flip();
        else if (horizontal < 0 && isFacingRight)
            Flip();

        // Handle jumping
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

    // Update is called once per frame
    // void Update()
    // {
    //     horizontal = Input.GetAxis("Horizontal");

    //     Flip();

    //     if (Input.GetButtonDown("Jump") && IsGrounded()) {
    //         rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    //     }
    //     if (Input.GetButtonUp("Jump") && rb.velocity.y>0f) {
    //         rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y* 0.5f);
    //     }
    // }

    // private void FixedUpdate() {
    //     Debug.Log("Horizontal Input: " + horizontal);
    //     rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    // }

    // private void Flip(){
    //     if (isFacingRight && horizontal <0f || !isFacingRight && horizontal>0f){
    //         isFacingRight = !isFacingRight;
    //         Vector3 localScale = transform.localScale;
    //         localScale.x *= -1f;
    //         transform.localScale = localScale;
    //     }
    // }

    // private bool IsGrounded() {
    //      RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.2f, groundLayer);
    //      Debug.DrawRay(groundCheck.position, Vector2.down * 0.2f, Color.red);
    //     Debug.Log("Ground Check Position: " + groundCheck.position);
    //     Debug.Log("Grounded: " + (hit.collider != null));
    //     return hit.collider != null;
    // }

    // //  private void OnCollisionEnter2D(Collision2D collision)
    // // {
    // //     // Example collision logic that sets deathState to true
    // //     if (collision.gameObject.CompareTag("Enemy"))
    // //     {
    // //         deathState = true;
    // //     }
    // // }

    // // private void OnTriggerEnter2D(Collider2D other)
    // // {
    // //     // Example trigger logic for collecting coins
    // //     if (other.gameObject.CompareTag("Coin"))
    // //     {
    // //         GameManager gm = FindObjectOfType<GameManager>();
    // //         gm.coinsCounter++;
    // //         Destroy(other.gameObject);
    // //     }
    // // }

//}
