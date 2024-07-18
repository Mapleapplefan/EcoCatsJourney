using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 21f;
    private bool isFacingRight= true;

[SerializeField] private Rigidbody2D rb;
[SerializeField] private Transform groundCheck;
[SerializeField] private LayerMask groundLayer; //add later

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        Flip();

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y>0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y* 0.5f);
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip(){
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal>0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.2f, groundLayer);
        Debug.DrawRay(groundCheck.position, Vector2.down * 0.2f, Color.red); // Visualize the raycast in the Scene view
        Debug.Log("Grounded: " + (hit.collider != null)); // Print whether the player is grounded
        return hit.collider != null;
    }

}
