using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Скрипт отвечает за передвижение персонажа
    public static float Speed = 10f;
    public static float JumpForce = 10f;
    private float _horizontal;
    private bool _isFacingRight;
    private bool _jumpButtonFlag;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            _jumpButtonFlag = true;
        }

        else if (!IsGrounded && Input.GetKeyUp(KeyCode.W) && _jumpButtonFlag)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            _jumpButtonFlag = false;
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_horizontal * Speed, rb.velocity.y);
    }

    private void Flip()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var rotation = transform.rotation;

        transform.eulerAngles = mousePos.x < transform.position.x
            ? new Vector3(rotation.x, 180f, rotation.z)
            : new Vector3(rotation.x, 0f, rotation.z);
    }

    private bool IsGrounded => Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    
}