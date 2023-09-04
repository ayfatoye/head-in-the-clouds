public float speed = 5f;
public float jumpForce = 5f; // This is the force applied when the player jumps

private float _moveX;
private Rigidbody2D _rb;
private bool _isJumping = false;

// Start is called before the first frame update
void Start()
{
    _rb = GetComponent<Rigidbody2D>();
}

// Update is called once per frame
void Update()
{
    _moveX = Input.GetAxis("Horizontal");
    _rb.velocity = new Vector2(_moveX * speed, _rb.velocity.y);

    if (Input.GetButtonDown("Jump") && !_isJumping)
    {
        _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        _isJumping = true;
    }
}

// This is a built-in Unity function that gets called when your GameObject
// collides with something. We are using it to determine if the player is touching the ground.
void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        _isJumping = false;
    }
}
