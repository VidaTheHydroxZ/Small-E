using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    

    [SerializeField] private LayerMask jumpableGround;

    private float PlayerStamina = 10f;
    [SerializeField] private Text Stamina;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool moveUp = false;
    private float horizontalMove;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
  
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;
        
    }
    
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerDownUp()
    {
        moveUp = true;
    }
    public void PointerUpUp()
    {
        moveUp = false;
    }

    private void MovementPlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -moveSpeed;
        }
        else if (moveRight)
        {
            horizontalMove = moveSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }
        if (moveUp)
        {
            if ((PlayerStamina > 2f && IsGrounded()))
            {
                PlayerStamina -= 2f;
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
    
    // Update is called once per frame
    private void Update()
    {
        
        MovementPlayer();
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        /*
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if ((PlayerStamina > 2f && Input.GetButtonDown("Jump")) && IsGrounded())
        {
            PlayerStamina -= 2f;
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        */
        if (PlayerStamina < 0f && Input.GetButtonDown("Jump") == true)
        {
            
        }
        
        PlayerStamina += Time.deltaTime;
        Stamina.text = "Stamina: " + Mathf.Round(PlayerStamina);
        Debug.Log(jumpForce);
        
        UpdateAnimationState();
        
      
    }

  

    private void UpdateAnimationState()
    {
        
        MovementState state;
        
        if (horizontalMove > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (horizontalMove < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        
        /*
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        */
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("State", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
