using System.Collections;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private float horizontal;
    
    private float speed = 15f;
    private float jumpingPower = 20f;
    private bool isFacingRight = true;

    private bool doubleJump;

    public int checkpointIndex;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 150f;
    private float dashingTime = 0.5f;
    private float dashingCooldown = 2f;

    [SerializeField] private KeyCode jump ;
    [SerializeField] private KeyCode dash ;
    [SerializeField] private string horizontalInputName;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        
        // if (IsGrounded()) {
        //     Debug.Log("test");
        // }
        
        // if (IsGrounded() && !Input.GetKeyDown(jump))
        // {
        //     doubleJump = false;
        // }

       
        if ((IsGrounded() || doubleJump) && Input.GetKeyDown(jump))
       
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            doubleJump = !doubleJump;
        }

        if (Input.GetKeyUp(jump) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(dash) && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
        
    }

    private void Start() {
        checkpointIndex = 0;
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        
        horizontal = Input.GetAxisRaw(horizontalInputName);
        

        
        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1.5f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void Stop()
 {
    rb.velocity = new Vector2(0, rb.velocity.y);
    enabled = false;
 }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

