using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform Player = null; // Variable where the Player's Transform lies
    [SerializeField] private float speed = 0f; // Speed of movement
    [SerializeField] private float jumpPower = 0f; // The power of the jump
    [SerializeField] private Rigidbody2D rb = null; // Rigidbody player

    [SerializeField] private Joystick joystick;
    
    [SerializeField, Range(35, 100)] private float cubeSize = 0; // Size of cube
    
    private bool _isGrounded = false; // Has the player landed
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); // Obtaining a Rigidbody of a player
        Player = this.transform; // Obtaining a player transform
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // The Player on the Ground
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") == true) // Player in flight
        {
            _isGrounded = false;
        }
    }

    void Update()
    {
        float x = joystick.Horizontal;

        Player.localScale = new Vector3(cubeSize * 0.01f,cubeSize * 0.01f);
        
        if( x >= 0.1f)
        {
            if (cubeSize >= 35)
            {
                rb.AddForce(new Vector2(x * speed * Time.deltaTime,0), ForceMode2D.Impulse);
                cubeSize -= x * 0.03f;
            }
        }
        else if( x <= -0.1f)
        {
            if (cubeSize >= 35)
            {
                rb.AddForce(new Vector2(x * speed * Time.deltaTime,0), ForceMode2D.Impulse);
                cubeSize -= x * -0.03f;
            }
        }
    }

    public void PlayerJump()
    {
        if (_isGrounded == true)
        {
            rb.AddForce(new Vector2(0,3 * jumpPower * Time.deltaTime), ForceMode2D.Impulse);
        }
    }
}
